using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using Bham.CmuCam.Packets;

namespace Bham.CmuCam.Packets {
	
	public class FPacket : Packet {
		
		private readonly Byte     _width;
		private readonly Byte     _height;
		private readonly Channels _channel;
		private readonly Color[,] _pixels;
		
		private readonly Size       _fullFrameSize;
		private readonly VirtualWindow _viewWindow;
		
		public FPacket(Byte width, Byte height, Size fullFrameSize, VirtualWindow window, Channels channel) {
			
			_width      = width;
			_height     = height;
			_channel    = channel;
			
			_fullFrameSize = fullFrameSize;
			_viewWindow    = window;
			
			_pixels = new Color[ width, height ];
		}
		
		public Byte     Width   { get { return _width; } }
		public Byte     Height  { get { return _height; } }
		public Channels Channel { get { return _channel; } }
		public Color[,] Pixels  { get { return _pixels; } }
		
		/// <summary>The size of the frame if the ViewWindow were to cover everything. This is related to the current camera resolution.</summary>
		public Size       FullFrameSize { get { return _fullFrameSize; } }
		/// <summary>The ViewWindow used when acquiring this particular frame.</summary>
		public VirtualWindow ViewWindow    { get { return _viewWindow; } }
		
		public Boolean IsSubsetOfFullFrame {
			get {
				
				if( ViewWindow.Left != 1 || ViewWindow.Top != 1 ) return true;
				if( ViewWindow.Width  != _fullFrameSize.Width  ) return true;
				if( ViewWindow.Height != _fullFrameSize.Height ) return true;
				return false;
			}
		}
		
#if UNSAFE
		
		public unsafe Bitmap ToBitmap() {
			
			Bitmap ret = new Bitmap( Width * 2, Height, PixelFormat.Format24bppRgb );
			BitmapData d = ret.LockBits(new Rectangle(0, 0, ret.Width, ret.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			
			for(int y=0;y<Height;y++) {
				for(int x=0;x<Width;x++) {
					// for each pixel in the original CMU frame bitmap
					// don't forget that horizontal res is halved
					
					Color p = Pixels[x,y];
					
					byte* dstB = (byte*)d.Scan0 + (y * d.Stride) + (x*2);
					byte* dstG = dstB + 1;
					byte* dstR = dstG + 1;
					
					*dstB = p.B;
					*dstG = p.G;
					*dstR = p.R;
					
					////////////////////////////////////////////
					// and again
					
					dstB = (byte*)d.Scan0 + (y * d.Stride) + (x*2+1);
					dstG = dstB + 1;
					dstR = dstG + 1;
					
					*dstB = p.B;
					*dstG = p.G;
					*dstR = p.R;
				}
			}
			
			ret.UnlockBits(d);
		}
#else
		
		public Bitmap ToBitmap() {	
			
			Bitmap ret = new Bitmap( Width * 2, Height, PixelFormat.Format24bppRgb );
			
			for(int y=0;y<Height;y++) {
				for(int x=0;x<Width;x++) {
					// for each pixel in the original CMU frame bitmap
					
					ret.SetPixel( x*2  , y, Pixels[x,y] );
					ret.SetPixel( x*2+1, y, Pixels[x,y] );
				}
			}
			
			return ret;
		}
#endif
		
	}
}
