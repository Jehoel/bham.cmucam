using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Bham.CmuCam.Gui {
	
	public static class Program {
		
		public static String ComPort;
		public static Int32  BaudRate;
		
		public static CmuCam2 Camera;
		
		[STAThread]
		public static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			PortSelectForm portSelect = new PortSelectForm();
			if( portSelect.ShowDialog() == DialogResult.OK ) {
				
				MainForm form = new MainForm();
				
				Application.Run( form );	
			}
			
			
		}
		
		public static Color GetPixelUnderCursor() {
			
			IntPtr desktopWindow = new IntPtr(0);
			IntPtr desktopDC     = NativeMethods.GetWindowDC( desktopWindow );
			
			Point cursorPos;
			NativeMethods.GetCursorPos(out cursorPos);
			
			Int32 color = NativeMethods.GetPixel( desktopDC, cursorPos.X, cursorPos.Y );
			
			Int32 r = color & 0x000000FF;
			Int32 g = (color & 0x0000FF00) >>  8;
			Int32 b = (color & 0x00FF0000) >> 16;
			return Color.FromArgb( r, g, b );
		}
		
		public static Control FindControl(Control parent, String name) {
			
			foreach(Control child in parent.Controls) {
				
				if( child.Name == name ) return child;
				
				Control found = FindControl( child, name );
				if( found != null ) return found;
			}
			
			return null;
		}
		
		public static Rectangle DeflateRectangle(Rectangle rect, Padding padding) {
			return new Rectangle(
				rect.X + padding.Left,
				rect.Y + padding.Top,
				rect.Width  - padding.Horizontal,
				rect.Height - padding.Vertical
			);
		}
		
	}
	
	internal static class NativeMethods {
		
		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr window);
		
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern Boolean GetCursorPos(out Point point);
		
		[DllImport("gdi32.dll")]
		public static extern Int32 GetPixel(IntPtr dc, int x, int y);
		
	}
	
}
