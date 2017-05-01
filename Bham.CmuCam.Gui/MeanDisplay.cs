using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Bham.CmuCam.Packets;

namespace Bham.CmuCam.Gui {
	
	public partial class MeanDisplay : Control {
		
		private Int32   _frameSize = 140;
		private SPacket _sPacket;
		
		public MeanDisplay() {
			InitializeComponent();
			
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			DoubleBuffered = true;
		}
		
		public SPacket SPacket {
			get { return _sPacket; }
			set {
				_sPacket = value;
				Invalidate();
			}
		}
		
		public Int32 FrameHeight {
			get { return _frameSize; }
			set {
				_frameSize = value;
				Invalidate();
			}
		}
		
		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);
			
			SPacket    s = _sPacket;
			SPacketM1 s1 = _sPacket as SPacketM1;
			SPacketM2 s2 = _sPacket as SPacketM2;
			
			if( s == null ) return;
			
			// draw three columns
			int width = (ClientSize.Width - 1) / 5;
			
			Graphics g = pe.Graphics;
			
			int colsStartAt = (int)g.MeasureString("-devMean+dev", SystemFonts.IconTitleFont).Height;
			
			g.DrawString("-dev", SystemFonts.IconTitleFont, SystemBrushes.ControlText,       0, 0);
			g.DrawString("Mean", SystemFonts.IconTitleFont, SystemBrushes.ControlText, 2*width, 0);
			g.DrawString("+dev", SystemFonts.IconTitleFont, SystemBrushes.ControlText, 4*width, 0);
			
			Rectangle colMinO = new Rectangle(       0, colsStartAt + 3, width, _frameSize + 2 );
			Rectangle colMeaO = new Rectangle( 2*width, colsStartAt + 3, width, _frameSize + 2 );
			Rectangle colMaxO = new Rectangle( 4*width, colsStartAt + 3, width, _frameSize + 2 );
			
			g.DrawRectangle( Pens.Black, colMinO );
			g.DrawRectangle( Pens.Black, colMeaO );
			g.DrawRectangle( Pens.Black, colMaxO );
			
			Rectangle colMin = Program.DeflateRectangle( colMinO, new Padding(1) ); colMin.Width++; colMin.Height++;
			Rectangle colMea = Program.DeflateRectangle( colMeaO, new Padding(1) );	colMea.Width++; colMea.Height++;
			Rectangle colMax = Program.DeflateRectangle( colMaxO, new Padding(1) ); colMax.Width++; colMax.Height++;
			
			Color mea = Color.FromArgb(                  s.RMean,                   s.GMean,                   s.BMean );
			Color min = Color.FromArgb( P( mea.R - s.RDeviation), P( mea.G - s.GDeviation ), P( mea.B - s.BDeviation ) );
			Color max = Color.FromArgb( P( mea.R + s.RDeviation), P( mea.G + s.GDeviation ), P( mea.B + s.BDeviation ) );
			
			if(	s2 != null ) {
				
				for(int y=0;y<s2.Rows.Count;y++) {
					
					SPacketM2Row row = s2.Rows[y];
					
					Color rowMea = Color.FromArgb(                     row.RMean,                      row.GMean,                    row.BMean   );
					Color rowMin = Color.FromArgb( P( rowMea.R - row.RDeviation), P( rowMea.G - row.GDeviation ), P( rowMea.B - row.BDeviation ) );
					Color rowMax = Color.FromArgb( P( rowMea.R + row.RDeviation), P( rowMea.G + row.GDeviation ), P( rowMea.B + row.BDeviation ) );
					
					g.FillRectangle( new SolidBrush( rowMin ), new Rectangle( colMin.X, colMin.Y + y, colMin.Width, 1 ) );
					g.FillRectangle( new SolidBrush( rowMea ), new Rectangle( colMea.X, colMea.Y + y, colMea.Width, 1 ) );
					g.FillRectangle( new SolidBrush( rowMax ), new Rectangle( colMax.X, colMax.Y + y, colMax.Width, 1 ) );
					
				}
				
			} else if( s1 != null ) {
				
				for(int y=0;y<s1.Rows.Count;y++) {
					
					SPacketM1Row row = s1.Rows[y];
					
					Color rowMea = Color.FromArgb(                   row.RMean,                   row.GMean,                     row.BMean );
					Color rowMin = Color.FromArgb( P( rowMea.R - s.RDeviation), P( rowMea.G - s.GDeviation ), P( rowMea.B - s.BDeviation ) );
					Color rowMax = Color.FromArgb( P( rowMea.R + s.RDeviation), P( rowMea.G + s.GDeviation ), P( rowMea.B + s.BDeviation ) );
					
					g.FillRectangle( new SolidBrush( rowMin ), new Rectangle( colMin.X, colMin.Y + y, colMin.Width, 1 ) );
					g.FillRectangle( new SolidBrush( rowMea ), new Rectangle( colMea.X, colMea.Y + y, colMea.Width, 1 ) );
					g.FillRectangle( new SolidBrush( rowMax ), new Rectangle( colMax.X, colMax.Y + y, colMax.Width, 1 ) );
					
				}
				
			} else {
				
				g.FillRectangle( new SolidBrush( min ), colMin );
				g.FillRectangle( new SolidBrush( mea ), colMea );
				g.FillRectangle( new SolidBrush( max ), colMax );
				
				
			}
			
			String minStr = String.Format("R: {0}\nG: {1}\nB: {2}", min.R, min.G, min.B);
			String meaStr = String.Format("R: {0}\nG: {1}\nB: {2}\n\ndR: {3}\ndG: {4}\ndB: {5}", mea.R, mea.G, mea.B, s.RDeviation, s.RDeviation, s.BDeviation);
			String maxStr = String.Format("R: {0}\nG: {1}\nB: {2}", max.R, max.G, max.B);
			
			g.DrawString(minStr, SystemFonts.IconTitleFont, SystemBrushes.ControlText,       0, colsStartAt + 3 + _frameSize + 5 );
			g.DrawString(meaStr, SystemFonts.IconTitleFont, SystemBrushes.ControlText, 2*width, colsStartAt + 3 + _frameSize + 5 );
			g.DrawString(maxStr, SystemFonts.IconTitleFont, SystemBrushes.ControlText, 4*width, colsStartAt + 3 + _frameSize + 5 );
			
		}
		
		private static int P(int v) {
			return Math.Max( Math.Min( v, 255 ), 0 );
		}
		
	}
}
