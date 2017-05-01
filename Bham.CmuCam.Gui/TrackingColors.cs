using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Bham.CmuCam.Gui {
	
	public static class TrackingColors {
		
		public static readonly Color RedMin    = Color.FromArgb(  90, 20, 0 );
		public static readonly Color RedMax    = Color.FromArgb( 255, 50, 22 );
		
		public static readonly Color GreenMin  = Color.FromArgb( 45,  90, 30 );
		public static readonly Color GreenMax  = Color.FromArgb( 60, 255, 50 );
		
		public static readonly Color YellowMin = Color.FromArgb( 185, 195, 0 );
		public static readonly Color YellowMax = Color.FromArgb( 255,  24, 0 );
		
		public static readonly Color BlueMin   = Color.FromArgb( 24, 30,  23 );
		public static readonly Color BlueMax   = Color.FromArgb( 30, 41, 255 );
		
		public static Color CustomMin = Color.Black;
		public static Color CustomMax = Color.Black;
		
		public static Color GetMidColor(Color min, Color max) {
			
			int r = min.R + (( max.R - min.R ) / 2);
			int g = min.G + (( max.G - min.G ) / 2);
			int b = min.B + (( max.B - min.B ) / 2);
			
			return Color.FromArgb( r, g, b );
		}
		
	}
}
