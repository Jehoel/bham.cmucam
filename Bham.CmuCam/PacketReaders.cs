using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

using Cult = System.Globalization.CultureInfo;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.IO;

namespace Bham.CmuCam.Packets {
	
	internal abstract class PacketReader<T> where T : Packet {
		
		public abstract T ReadPacket(SerialPort port);
		
		protected static void ReadBinaryBitmapAA(SerialPort port, out Byte width, out Byte height, out int stride, out Byte[] bitmap) {
			
			// 0xAA width height byte[len] 0xAA 0xAA TPacket
			// 
			// Where there are 'len' many bytes as 8-pixels (padded with zeros to fill integral number of bytes)
			
			Byte tag = (byte)port.ReadByte();
			if( tag != 0xAA ) throw new FormatException("Expected 0xAA tag byte.");
			
			ReadBinaryBitmap(port, out width, out height, out stride, out bitmap);
			
			tag = (byte)port.ReadByte();
			if( tag != 0xAA ) throw new FormatException("Expected 0xAA tag byte.");
			tag = (byte)port.ReadByte();
			if( tag != 0xAA ) throw new FormatException("Expected 0xAA tag byte.");
		}
		
		protected static void ReadBinaryBitmapFCFD(SerialPort port, out Byte width, out Byte height, out int stride, out Byte[] bitmap) {
			
			// 0xFC width height byte[len] 0xFD 
			
			Byte tag = (byte)port.ReadByte();
			if( tag != 0xFC ) throw new FormatException("Expected 0xFC tag byte.");
			
			ReadBinaryBitmap(port, out width, out height, out stride, out bitmap);
			
			tag = (byte)port.ReadByte();
			if( tag != 0xFD ) throw new FormatException("Expected 0xFD tag byte.");
		}
		
		private static void ReadBinaryBitmap(SerialPort port, out Byte width, out Byte height, out int stride, out Byte[] bitmap) {
			
			width  = (byte)port.ReadByte();
			height = (byte)port.ReadByte();
			
			stride = (int)Math.Ceiling( (float)width / 8f );
			
			bitmap = new Byte[ stride * height ];
			// don't use port.Read(Byte[]) because it only reads from the buffer
			
			for(int i=0;i<bitmap.Length;i++) bitmap[i] = (byte)port.ReadByte();
		}
		
	}
	
	internal class TPacketReader : PacketReader<TPacket> {
		
		private Boolean _ignoreSPacket0;
		private Boolean _seenSPacket;
		
		public TPacketReader() : this(true) {
		}
		
		public TPacketReader(bool ignoreFirstSPacket) {
			
			_ignoreSPacket0 = ignoreFirstSPacket;
		}
		
		public override TPacket ReadPacket(SerialPort port) {
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			if( line.Length > 0 && line[0] == 'S' ) {
				
				if( _ignoreSPacket0 && !_seenSPacket ) {
					line = port.ReadLine(); // skip to the next packet
					_seenSPacket = true;
				}
			}
			
			return new TPacket(line);
		}
	}
	
	internal class TPacketM1Reader : PacketReader<TPacketM1> {
		
		public override TPacketM1 ReadPacket(SerialPort port) {
			
			Byte width, height;
			int stride;
			Byte[] bitmap;
			
			ReadBinaryBitmapAA(port, out width, out height, out stride, out bitmap);
			
			String tPacket = port.ReadLine();
			
			return new TPacketM1(width, height, stride, bitmap, tPacket);
		}
		
	}
	
	internal class TPacketM2Reader : PacketReader<TPacketM2> {
		
		public override TPacketM2 ReadPacket(SerialPort port) {
			
			// Line Mode 2 Track Packet format:
			
			// 0xFE height (xMean xMin xMax xCount confidence) 0xFD TPacket
			
			Byte tag = (byte)port.ReadByte();
			if( tag != 0xFE ) throw new FormatException("Expected 0xFE tag byte.");
			
			Byte height = (byte)port.ReadByte();
			
			TPacketM2Row[] rows = new TPacketM2Row[ height ];
			
			for(int i=0;i<height;i++) {
				
				Byte mean = (byte)port.ReadByte();
				Byte min  = (byte)port.ReadByte();
				Byte max  = (byte)port.ReadByte();
				Byte cnt  = (byte)port.ReadByte();
				Byte conf = (byte)port.ReadByte();
				
				TPacketM2Row row = new TPacketM2Row(mean, min, max, cnt, conf);
				
				rows[i] = row;
			}
			
			tag = (byte)port.ReadByte();
			if( tag != 0xFD ) throw new FormatException("Expected 0xFD tag byte.");
			
			String tPacket = port.ReadLine();
			
			return new TPacketM2(rows, tPacket);
		}
	}
	
	internal class DPacketReader : PacketReader<DPacket> {
		
		public Int32 Resolution { get; set; }
		
		public override DPacket ReadPacket(SerialPort port) {
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			
			return new DPacket( Resolution, Resolution, line);
		}
	}
	
	internal class DPacketM1Reader : PacketReader<DPacketM1> {
		
		public Int32 Resolution { get; set; }
		
		public override DPacketM1 ReadPacket(SerialPort port) {
			
			Byte width, height;
			int stride;
			Byte[] bitmap;
			
			ReadBinaryBitmapAA(port, out width, out height, out stride, out bitmap);
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			
			return new DPacketM1(width, height, bitmap, Resolution, Resolution, line);
		}
	}
	
	internal class DPacketM2Reader : PacketReader<DPacketM2> {
		
		public Int32 Resolution { get; set; }
		
		public override DPacketM2 ReadPacket(SerialPort port) {
			
			Byte width, height;
			int stride;
			Byte[] bitmap;
			
			ReadBinaryBitmapFCFD(port, out width, out height, out stride, out bitmap);
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			
			return new DPacketM2(width, height, bitmap, Resolution, Resolution, line);
		}
	}
	
	internal class DPacketM3Reader : PacketReader<DPacketM3> {
		
		public Int32 Resolution { get; set; }
		
		public override DPacketM3 ReadPacket(SerialPort port) {
			
			Byte width, height;
			int stride;
			Byte[] bitmap;
			
			ReadBinaryBitmapFCFD(port, out width, out height, out stride, out bitmap);
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			
			return new DPacketM3(width, height, bitmap, Resolution, Resolution, line);
		}
	}
	
	internal class SPacketReader : PacketReader<SPacket> {
		
		public override SPacket ReadPacket(SerialPort port) {
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			
			return new SPacket( line );
		}
	}
	
	internal class SPacketM1Reader : PacketReader<SPacketM1> {
		
		public override SPacketM1 ReadPacket(SerialPort port) {
			
			// 0xFE (rMean gMean bMean) 0xFD sPacket
			
			// read until 0xFD, because 0xFD > 240
			
			Byte tag = (byte)port.ReadByte();
			if( tag != 0xFE ) throw new FormatException("Expected 0xFE tag byte.");
			tag = (byte)port.ReadByte(); // seemingly extraaneous byte
			
			List<SPacketM1Row> rows = new List<SPacketM1Row>();
			
			while(true) {
				
				Byte rMean = (byte)port.ReadByte();
				
				if( rMean == 0xFD )
					break;
				
				Byte gMean = (byte)port.ReadByte();
				Byte bMean = (byte)port.ReadByte();
				
				SPacketM1Row row = new SPacketM1Row(rMean, gMean, bMean);
				rows.Add( row );
				
			}
			
			Debug.WriteLine("M1 with " + rows.Count + " rows");
			
			String sPacket = port.ReadLine();
			
			return new SPacketM1( rows.ToArray(), sPacket );
		}
		
	}
	
	internal class SPacketM2Reader : PacketReader<SPacketM2> {
		
		public override SPacketM2 ReadPacket(SerialPort port) {
			
			// 0xFE (rMean gMean bMean rDev gDev bDev) 0xFD sPacket
			
			// read until 0xFD, because 0xFD > 240
			
			Byte tag = (byte)port.ReadByte();
			if( tag != 0xFE ) throw new FormatException("Expected 0xFE tag byte.");
			tag = (byte)port.ReadByte(); // seemingly extraaneous byte
			
			List<SPacketM2Row> rows = new List<SPacketM2Row>();
			
			while(true) {
				
				Byte rMean = (byte)port.ReadByte();
				
				if( rMean == 0xFD ) break;
				
				Byte gMean = (byte)port.ReadByte();
				Byte bMean = (byte)port.ReadByte();
				Byte rDev  = (byte)port.ReadByte();
				Byte gDev  = (byte)port.ReadByte();
				Byte bDev  = (byte)port.ReadByte();
				
				SPacketM2Row row = new SPacketM2Row(rMean, rDev, gMean, gDev, bMean, bDev);
				rows.Add( row );
			}
			
			String sPacket = port.ReadLine();
			
			return new SPacketM2( rows.ToArray(), sPacket );
		}
		
	}
	
	internal class HPacketReader : PacketReader<HPacket> {
		
		public override HPacket ReadPacket(SerialPort port) {
			
			String line = port.ReadLine(); // assuming '\r' sentinel and NewLine
			return new HPacket( line );
		}
	}
	
	internal class FPacketReader : PacketReader<FPacket> {
		
		public Size          FullFrameSize { get; set; }
		public Channels      Channels      { get; set; }
		public VirtualWindow VirtualWindow { get; set; }
		public Boolean       Streaming     { get; set; }
		
		public event EventHandler<FrameProgressEventArgs> FrameProgress;
		
		public override FPacket ReadPacket(SerialPort port) {
			
			// Frame byte format:
			
			// newFrame {
			//		byte flag == 1
			//		byte width
			//		byte height
			// }
			// row {
			//		byte flag == 2 // it seems the first row does NOT start with a '2'
			//		byte[3] rgb // note that the horizontal res is halved, so this represents two pixels
			// } (repeat)
			// eof {
			//		byte flag == 3
			// }
			
			// NOTE: If only one channel is selected, there will only be one byte
			
			// NOTE:
			// I'm using a hack-job using lists for pixel capture because I find the protocol to be a tad unreliable
			// it's not like performance is bad or anything
			
			Byte flag = (byte)port.ReadByte();
			if( flag != 1 ) throw new CmuCamException("Expected Frame Packet Tag '1'");
			
			Byte width  = (byte)port.ReadByte();
			Byte height = (byte)port.ReadByte();
			
			FPacket frame = new FPacket(width, height, FullFrameSize, VirtualWindow, Channels);
			
			List<List<Color>> rows = new List<List<Color>>();
			List<Color>       row  = new List<Color>();
			
			int i=0;;
			bool done = false;
			
			byte r=0,g=0,b=0;
			
			while(!done) {
				
				Byte d = (byte)port.ReadByte();
				switch(d) {
					case 0:
						break;
					case 1:
						break;
					case 2:
						
						if( row.Count > 0 ) rows.Add( row );
						row = new List<Color>();
						
						if( FrameProgress != null ) FrameProgress(this, new FrameProgressEventArgs( 100f * ( (float)rows.Count / (float)height ) ) );
						
						break;
					case 3:
						done = true;
						break;
					default:
						if( d < 16 || d > 240 ) throw new CmuCamException("Byte outside expected range");
						
						if( Channels != Channels.All ) {
							
							row.Add( Color.FromArgb( d,d,d ) );
							
						} else {
							
							switch(i) {
								case 0: r = d; break;
								case 1: g = d; break;
								case 2: b = d; break;
							}
							if( ++i == 3 ) {
								i = 0;
								row.Add( Color.FromArgb( r,g,b ) );
							}
							
						}
						
						break;
				}
			}
			
			/////////////////////////////////
			
			List<Color[]> rows2 = new List<Color[]>();
			int len = Int32.MinValue;
			foreach(List<Color> row2 in rows) {
				
				Color[] rowC = row2.ToArray();
				rows2.Add( rowC );
				
				if(len == Int32.MinValue) len = rowC.Length;
				if( len != rowC.Length ) throw new CmuCamException("Bad bitmap.");
			}
			
			for(int y=0;y<rows2.Count;y++) {
				for(int x=0;x<len;x++) {
					
					frame.Pixels[x,y] = rows2[y][x];
				}
			}
			
			if( !Streaming ) {
				
				Char colon = (char)port.ReadChar();
				if( colon != ':' ) throw new CmuCamException("Unexpected response: " + colon);
			}
			
			if( FrameProgress != null ) FrameProgress(this, new FrameProgressEventArgs( -1 ) );
			
			return frame;
		}
		
	}
	
}
