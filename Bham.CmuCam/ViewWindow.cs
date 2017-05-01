using System;
using System.Collections.Generic;
using System.Text;

namespace Bham.CmuCam {
	
	public class VirtualWindow {
		
		private readonly Byte _l; // x
		private readonly Byte _t; // y
		
		private readonly Byte _r; // x2
		private readonly Byte _b; // y2
		
		public VirtualWindow(Byte left, Byte top, Byte right, Byte bottom) {
			_l = left;
			_t = top;
			_r = right;
			_b = bottom;
		}
		
		public Byte Left   { get { return _l; } }
		public Byte Top    { get { return _t; } }
		
		public Byte Right  { get { return _r; } }
		public Byte Bottom { get { return _b; } }
		
		public Int32 Width  { get { return Right - Left; } }
		public Int32 Height { get { return Bottom - Top; } }
	}
}
