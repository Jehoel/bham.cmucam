using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bham.CmuCam.Gui {
	
	public partial class HistogramDisplay : Control {
		
		private Color        _histogramColor;
		private IList<Int32> _histogramData;
		
		private Point   _mouseCoords;
		
		public HistogramDisplay() {
			InitializeComponent();
			
			this.DoubleBuffered = true;
		}
		
		public Color HistogramColor {
			get { return _histogramColor; }
			set { _histogramColor = value; Invalidate(); }
		}
		
		public IList<Int32> HistogramData {
			get { return _histogramData; }
			set { _histogramData = value; Invalidate(); }
		}
		
		protected override void OnMouseMove(MouseEventArgs e) {
			base.OnMouseMove(e);
			
			_mouseCoords = new Point( e.X, e.Y );
			Invalidate();
		}
		
		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			
//			_mouseCoords = Point.Empty;
		}
		
		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);
			
			Graphics g = pe.Graphics;
			
			g.DrawRectangle( Pens.Black, 0, 0, Width - 1, Height - 1 );
			
			if( _histogramData == null ) return;
			
			int colWidth = Width / _histogramData.Count;
			
			Brush b = new SolidBrush( HistogramColor );
			
			float yScale = (float)this.Height / 255f;
			
			int total = 0;
			for(int i=0;i<_histogramData.Count;i++) {
				
				int x = i * colWidth;
				int height = (int)(yScale * _histogramData[i]); // the value-per-bin is capped at 255
				
				total += _histogramData[i];
				
				g.FillRectangle( b, x, this.Height - height, colWidth, height );
			}
			
			//////////////////////////////
			
			if( _mouseCoords != Point.Empty ) {
				
				// get the bin the cursor is in
				int binIdx = _mouseCoords.X / colWidth;
				if( binIdx < _histogramData.Count ) {
					
					int data = _histogramData[binIdx];
					
					// RGB values are from 16 to 240
					// but bin width varies
					
					int binMin = 16 + ((240-16) / _histogramData.Count) * binIdx;
					int binMax = binMin + ((240-16) / _histogramData.Count);
					
					String text = String.Format("Bin [{0}] - {1} to {2} - Count: {3}", binIdx, binMin, binMax, data);
					g.DrawString(text, SystemFonts.IconTitleFont, SystemBrushes.ControlText, 5, 5);
				}
			}
			
			String ttext = "Total: " + total + " pixels";
			int tWidth = (int)g.MeasureString(ttext, SystemFonts.IconTitleFont).Width;
			g.DrawString(ttext, SystemFonts.IconTitleFont, SystemBrushes.ControlText, Width - tWidth - 5, 5 );
		}
		
	}
	
}
