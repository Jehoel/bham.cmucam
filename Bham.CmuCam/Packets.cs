using System;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Text;

using Cult = System.Globalization.CultureInfo;
using System.IO.Ports;
using System.Drawing.Imaging;

namespace Bham.CmuCam.Packets {
	
	public abstract class Packet {
	}
	
#region Tracking
	
	/// <summary>Contains color-tracking data from a CMUcam and possibly Tracking Servo positions.</summary>
	public class TPacket : Packet {
		
		public TPacket(String line) {
			
			String[] components = line.Split(' ');
			if( components.Length < 7 ) throw new FormatException("Line was not in the format expected.");
			if( components[0] != "T" ) throw new ArgumentException("Line does not start with a T-packet tag.");
			
			int mx = Int32.Parse( components[1], Cult.InvariantCulture );
			int my = Int32.Parse( components[2], Cult.InvariantCulture );
			
			Centroid = new Point( mx, my );
			
			int x1 = Int32.Parse( components[3], Cult.InvariantCulture );
			int y1 = Int32.Parse( components[4], Cult.InvariantCulture );
			
			int x2 = Int32.Parse( components[5], Cult.InvariantCulture );
			int y2 = Int32.Parse( components[6], Cult.InvariantCulture );
			
			Rectangle = new Rectangle( x1 - 1, y1 - 1, x2 - x1, y2 - y1 );
			
			if( components.Length >=  8 ) PixelCount = Int32.Parse( components[7], Cult.InvariantCulture );
			if( components.Length >=  9 ) Confidence = Int32.Parse( components[8], Cult.InvariantCulture );
			
			if( components.Length >= 10 ) Servo1     = Byte.Parse( components[ 9], Cult.InvariantCulture );
			if( components.Length >= 11 ) Servo2     = Byte.Parse( components[10], Cult.InvariantCulture );
		}
		
		public Point     Centroid   { get; private set; }
		public Rectangle Rectangle  { get; private set; }
		public Int32     PixelCount { get; private set; }
		public Int32     Confidence { get; private set; }
		
		public Byte      Servo1     { get; private set; }
		public Byte      Servo2     { get; private set; }
		
	}
	
	/// <summary>A TPacket in Line Mode 1 with extra data: a binary image of the pixels being tracked.</summary>
	public class TPacketM1 : TPacket {
		
		private Byte[] _bitmap;
		
		public TPacketM1(Byte width, Byte height, int stride, Byte[] bitmap, String tPacket) : base( tPacket ) {
			
			Width  = width;
			Height = height;
			Stride = stride;
			
			_bitmap = bitmap;
		}
		
		public Byte       Width  { get; private set; } // Width of the image, in pixels
		public Byte       Height { get; private set; }
		public Int32      Stride { get; private set; } // Length of each scanline, in bytes
		
		public Bitmap ToBitmap() {
			
			Bitmap ret = new Bitmap(Width * 2, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			
			using(Graphics g = Graphics.FromImage(ret)) g.FillRectangle( Brushes.Transparent, 0, 0, Width, Height );
			
			int width2 = (Width + 7) / 8;
			
			for(int y=0;y<Height;y++) {
				for(int x=0;x<width2;x++) {
					
					for(int t=0;t<8;t++) {
						
						int     b = _bitmap[(y * width2) + x] >> t;
						Boolean bi = (b & 0x1) == 1;
						if( bi ) {
							
							ret.SetPixel(x * 2    , y, Color.Cyan);
							ret.SetPixel(x * 2 + 1, y, Color.Cyan);
						}
						
					}
					
				}
			}
			
			return ret;
		}
		
	}
	
	/// <summary>A TPacket in Line Mode 2 with extra data: the mean, min, max, count, and confidence for every line in the image.</summary>
	public class TPacketM2 : TPacket {
		
		// Mode 2 format:
		// 0xFE y-size (xLineMean xLineMin xLineMax LineCount Conf) 0xFD Tpacket
		
		public TPacketM2(TPacketM2Row[] rows, String tPacket) : base( tPacket ) {
			
			Rows = rows;
		}
		
		public TPacketM2Row[] Rows { get; private set; }
	}
	
	public class TPacketM2Row {
		
		public TPacketM2Row(Byte mean, Byte min, Byte max, Byte pixelCount, Byte confidence) {
			
			Mean = mean;
			Min  = min;
			Max  = max;
		}
		
		public Byte Mean        { get; private set; }
		public Byte Min         { get; private set; }
		public Byte Max         { get; private set; }
		public Byte PixelCount  { get; private set; }
		public Byte Confidence  { get; private set; }
	}
	
#endregion
#region Differencing
	
	/// <summary>A TPacket, but used for motion/difference tracking.</summary>
	public class DPacket : TPacket {
		
		public DPacket(int xAxisSegments, int yAxisSegments, String tPacket) : base(tPacket) {
			
			XAxisSegments = xAxisSegments;
			YAxisSegments = yAxisSegments;
		}
		
		public Int32 XAxisSegments { get; private set; }
		public Int32 YAxisSegments { get; private set; }
		
	}
	
	public class DPacketM1 : DPacket {
		
		private Byte[] _bitmap;
		
		public DPacketM1(Byte width, Byte height, Byte[] bitmap, int xAxisSegments, int yAxisSegments, String dPacket) : base(xAxisSegments, yAxisSegments, dPacket) {
			
			Width  = width;
			Height = height;
			_bitmap = bitmap;
		}
		
		public Byte Width  { get; private set; } // Width of the image, in pixels
		public Byte Height { get; private set; }
		
	}
	
	public class DPacketM2 : DPacketM1 {
		
		public DPacketM2(Byte width, Byte height, Byte[] bitmap, int xAxisSegments, int yAxisSegments, String dPacket) : base(width, height, bitmap, xAxisSegments, yAxisSegments, dPacket) {
		}
	}
	
	public class DPacketM3 : DPacketM2 {
		
		public DPacketM3(Byte width, Byte height, Byte[] bitmap, int xAxisSegments, int yAxisSegments, String dPacket) : base(width, height, bitmap, xAxisSegments, yAxisSegments, dPacket) {
		}
	}
	
#endregion
#region Statistics
	
	/// <summary>Contains the histogram of color distribution of a single channel in a CMUcam image frame.</summary>
	public class HPacket : Packet {
		
		// HPackets can have either 28, 14, or 7 bins
		// note that there exists a scale parameter too, defined using HC, but I don't think it's possible to retrieve
		
		private readonly Int32[]                   _histogram;
		private readonly ReadOnlyCollection<Int32> _histogramC;
		
		public HPacket(String line) {
			
			String[] components = line.Split(' ');
			if( components.Length != 29 && components.Length != 15 && components.Length != 8 ) throw new FormatException("Line was not in the format expected.");
			if( components[0] != "H" ) throw new ArgumentException("Line does not start with an H-packet tag.");
			
			_histogram = new Int32[ components.Length - 1 ];
			for(int i=0;i<_histogram.Length;i++) {
				
				_histogram[i] = Int32.Parse( components[i+1], Cult.InvariantCulture );
			}
			
			_histogramC = new ReadOnlyCollection<Int32>( _histogram );
		}
		
		public ReadOnlyCollection<Int32> Histogram {
			get { return _histogramC; }
		}
		
	}
	
	/// <summary>Contains statistical data, the Mean color value and Absolute Deviation.</summary>
	public class SPacket : Packet {
		
		public SPacket(String line) {
			
			String[] components = line.Split(' ');
			if(components.Length != 7) throw new FormatException("Line was not in the format expected.");
			if(components[0] != "S") throw new ArgumentException("Line does not start with an S-packet tag.");
			
			RMean      = Byte.Parse( components[1], Cult.InvariantCulture );
			GMean      = Byte.Parse( components[2], Cult.InvariantCulture );
			BMean      = Byte.Parse( components[3], Cult.InvariantCulture );
			
			RDeviation = Byte.Parse( components[4], Cult.InvariantCulture );
			GDeviation = Byte.Parse( components[5], Cult.InvariantCulture );
			BDeviation = Byte.Parse( components[6], Cult.InvariantCulture );
		}
		
		public Byte RMean      { get; private set; }
		public Byte RDeviation { get; private set; }
		
		public Byte GMean      { get; private set; }
		public Byte GDeviation { get; private set; }
		
		public Byte BMean      { get; private set; }
		public Byte BDeviation { get; private set; }
		
	}
	
	public class SPacketM1 : SPacket {
		
		private readonly SPacketM1Row[] _rows;
		private readonly ReadOnlyCollection<SPacketM1Row> _rowsC;
		
		public SPacketM1(SPacketM1Row[] rows, String sPacket) : base( sPacket ) {
			
			_rows  = rows;
			_rowsC = new ReadOnlyCollection<SPacketM1Row>( rows );
		}
		
		public ReadOnlyCollection<SPacketM1Row> Rows { get { return _rowsC; } }
		
	}
	
	public class SPacketM1Row {
		
		public SPacketM1Row(Byte rMean, Byte gMean, Byte bMean) {
			
			RMean = rMean;
			GMean = gMean;
			BMean = bMean;
		}
		
		public Byte RMean { get; private set; }
		public Byte GMean { get; private set; }
		public Byte BMean { get; private set; }
		
	}
	
	public class SPacketM2 : SPacket {
		
		private readonly SPacketM2Row[] _rows;
		private readonly ReadOnlyCollection<SPacketM2Row> _rowsC;
		
		public SPacketM2(SPacketM2Row[] rows, String sPacket) : base( sPacket ) {
			
			_rows  = rows;
			_rowsC = new ReadOnlyCollection<SPacketM2Row>( rows );
		}
		
		public ReadOnlyCollection<SPacketM2Row> Rows { get { return _rowsC; } }
		
	}
	
	public class SPacketM2Row : SPacketM1Row {
		
		public SPacketM2Row(Byte rMean, Byte rDev, Byte gMean, Byte gDev, Byte bMean, Byte bDev) : base(rMean, gMean, bMean) {
			
			RDeviation = rDev;
			GDeviation = gDev;
			BDeviation = bDev;
		}
		
		public Byte RDeviation { get; private set; }
		public Byte GDeviation { get; private set; }
		public Byte BDeviation { get; private set; }
		
	}
	
#endregion
	
}