using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Drawing.Imaging;

using Bham.CmuCam.Packets;

namespace Bham.CmuCam.Gui {
	
	/// <summary>Displays images from a CMUcam2 camera, overlayed with relevant data if provided.</summary>
	/// <remarks>I can't extend from PictureBox because .ImageRectangle is a private property.</remarks>
	public partial class CmuView : Control {
		
		private Bitmap             _cmuFrameBmp;
		private FPacket            _cmuFrame;
		
		private PictureBoxSizeMode _sizeMode;
		private Size               _frameSizeFallback;
		
		private DPacket            _dPacket;
		private TPacket            _tPacket;
		private Color              _tColor;
		
		private Boolean            _showImage    = true;
		private Boolean            _showOverlays = true;
		
		public CmuView() {
			InitializeComponent();
			
			this.DoubleBuffered = true;
		}
		
#region Border Style
		
		private BorderStyle _borderStyle;
		
		[DefaultValue(0), Category("Appearance")]
		public BorderStyle BorderStyle {
			get {
				return this._borderStyle;
			}
			set {
				if (this._borderStyle != value) {
					this._borderStyle = value;
					base.RecreateHandle();
				}
			}
		}
		
		protected override CreateParams CreateParams {
			[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
			get {
				CreateParams createParams = base.CreateParams;
				switch (this._borderStyle) {
					case BorderStyle.FixedSingle:
						createParams.Style |= 0x800000;
						return createParams;
					case BorderStyle.Fixed3D:
						createParams.ExStyle |= 0x200;
						return createParams;
				}
				return createParams;
			}
		}
		
#endregion
		
		public FPacket Frame {
			get { return _cmuFrame; }
			set {
				_cmuFrame = value;
				if( value != null ) {
					if( _cmuFrameBmp != null ) _cmuFrameBmp.Dispose();
					_cmuFrameBmp = value.ToBitmap();
				}
				Invalidate();
			}
		}
		
		public Bitmap FrameImage {
			get {
				return _cmuFrameBmp;
			}
		}
		
		public Size FrameSizeFallback {
			get { return _frameSizeFallback; }
			set {
				if( _frameSizeFallback != value ) {
					
					_frameSizeFallback = value;
					Invalidate();
				}
			}
		}
		
		public TPacket TrackPacket {
			get { return _tPacket; }
			set {
				_tPacket = value;
				Invalidate();
			}
		}
		
		public DPacket DifferencePacket {
			get { return _dPacket; }
			set {
				_dPacket = value;
				Invalidate();
			}
		}
		
		public Color TrackColor {
			get { return _tColor; }
			set {
				_tColor = value;
				Invalidate();
			}
		}
		
		/// <summary>Gets the drawing rectangle for the whole frame.</summary>
		protected Rectangle FrameRectangle {
			get {
				if( _cmuFrame == null ) return ImageRectangleFromSizeMode( _frameSizeFallback, _sizeMode );
				return ImageRectangleFromSizeMode( _cmuFrame.FullFrameSize, _sizeMode );
			}
		}
		
		public PictureBoxSizeMode SizeMode {
			get { return _sizeMode; }
			set {
				
				if( value != _sizeMode ) {
					
					_sizeMode = value;
					
					Invalidate();
				}
			}
		}
		
		public Boolean ShowImage {
			get { return _showImage; }
			set {
				_showImage = value;
				Invalidate();
			}
		}
		
		public Boolean ShowOverlays {
			get { return _showOverlays; }
			set {
				_showOverlays = value;
				Invalidate();
			}
		}
		
		protected Point TransformPoint(Point framePoint) {
			
			float percX = (float)framePoint.X / (float)_frameSizeFallback.Width;
			float percY = (float)framePoint.Y / (float)_frameSizeFallback.Height;
			
			Rectangle r = FrameRectangle;
			
			float x = FrameRectangle.X + ( percX * r.Width  );
			float y = FrameRectangle.Y + ( percY * r.Height );
			
			return new Point( (int)x, (int)y );
		}
		
		protected Rectangle TransformRect(Rectangle rect) {
			
			Point topLeft = new Point( rect.X, rect.Y );
			topLeft = TransformPoint( topLeft );
			
			Point botRight = new Point( rect.X + rect.Width, rect.Y + rect.Height );
			botRight = TransformPoint( botRight );
			
			return new Rectangle( topLeft.X, topLeft.Y, botRight.X - topLeft.X, botRight.Y - topLeft.Y );
		}
		
		protected Rectangle ImageRectangleFromSizeMode(Size fullFrameSize, PictureBoxSizeMode mode) {
			
			int ffWidth = fullFrameSize.Width * 2;
			
			Rectangle rect = Program.DeflateRectangle(this.ClientRectangle, Padding);
			switch(mode) {
				
				case PictureBoxSizeMode.StretchImage:
					return rect;
				
				case PictureBoxSizeMode.CenterImage:
					rect.X += (rect.Width  - ffWidth ) / 2;
					rect.Y += (rect.Height - fullFrameSize.Height) / 2;
					rect.Size = fullFrameSize;
					return rect;
					
				case PictureBoxSizeMode.Zoom:
					
					float zoomRatioX = (float)rect.Width  / (float)ffWidth;
					float zoomRatioY = (float)rect.Height / (float)fullFrameSize.Height;
					
					float zoomRatio = Math.Min( zoomRatioX, zoomRatioY );
					
					int rectWidth  = (int)( ffWidth  * zoomRatio );
					int rectHeight = (int)( fullFrameSize.Height * zoomRatio );
					
					return new Rectangle(
						(rect.Width  - rectWidth ) / 2,
						(rect.Height - rectHeight) / 2,
						rectWidth,
						rectHeight
					);
					
				case PictureBoxSizeMode.Normal:
				case PictureBoxSizeMode.AutoSize:
				default:
					rect.Size = new Size( ffWidth, fullFrameSize.Height );
					return rect;
			}
			
		}
		
		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);
			
			try {
				
				Rectangle rect = FrameRectangle;
				pe.Graphics.DrawRectangle( Pens.Black, rect );
				
				if( _showImage ) {
					
					PaintFrame(pe.Graphics);
				}
				
				if( _showOverlays ) {
					
					PaintDifference(pe.Graphics);
					
					PaintTracking(pe.Graphics);
				}
			
			} catch(Exception ex) {
				
				Graphics g = pe.Graphics;
				g.FillRectangle( Brushes.White, 0, 0, Width, Height );
				
				SizeF size = g.MeasureString( ex.Message, SystemFonts.IconTitleFont, Width - 10 );
				g.DrawString( ex.Message, SystemFonts.IconTitleFont, Brushes.Black, new RectangleF(5, 5, Width - 10, Height ), StringFormat.GenericDefault );
				
				size = g.MeasureString( ex.StackTrace, SystemFonts.IconTitleFont );
				g.DrawString( ex.StackTrace, SystemFonts.IconTitleFont, Brushes.Black, 10, size.Height + 10 );
				
				
			}
			
		}
		
		protected void PaintFrame(Graphics g) {
			
			if( Frame == null ) return;
			
			if( _cmuFrame.IsSubsetOfFullFrame ) {
				
				Rectangle virtualWindow = new Rectangle( _cmuFrame.ViewWindow.Left - 1, _cmuFrame.ViewWindow.Top - 1, _cmuFrame.ViewWindow.Width, _cmuFrame.ViewWindow.Height );
				virtualWindow = TransformRect( virtualWindow );
				
				g.DrawImage( _cmuFrameBmp, virtualWindow );
				
			} else {
				
				g.DrawImage( _cmuFrameBmp, FrameRectangle );
			}
			
		}
		
		protected void PaintDifference(Graphics g) {
			
			DPacket p = _dPacket;
			if( p == null ) return;
			
			//////////////////////////////////////
			// Draw gridlines
			Rectangle rect = FrameRectangle;
			int cellWidth  = (int)( (float)rect.Width  / (float)p.XAxisSegments );
			int cellHeight = (int)( (float)rect.Height / (float)p.YAxisSegments );
			
			for(int y=0;y<p.XAxisSegments;y++) {
				for(int x=0;x<p.YAxisSegments;x++) {
					
					Rectangle thisCell = new Rectangle( rect.X + x * cellWidth, rect.Y + y * cellHeight, cellWidth, cellHeight );
					
					g.DrawRectangle( Pens.Black, thisCell );
					
					if( p.PixelCount > 0 ) {
						
						if( p.Rectangle.Contains( x, y ) ) {
							
							g.FillRectangle( Brushes.Blue, thisCell );
						}
						
						if( p.Centroid.X - 1 == x && p.Centroid.Y - 1 == y ) {
							
							g.FillRectangle( Brushes.White, thisCell );
						}
						
					}//if
				}//for
			}//for
			
			String text = String.Format("Confidence: {0}\nPixel Count: {1}", p.Confidence, p.PixelCount);
			g.DrawString( text, SystemFonts.IconTitleFont, SystemBrushes.ControlText, 5, FrameRectangle.Height + 5 );
			
		}
		
		protected void PaintTracking(Graphics g) {
			
			TPacket    p = _tPacket;
			TPacketM1 p1 = p as TPacketM1;
			TPacketM2 p2 = p as TPacketM2;
			if( p == null ) return;
			
			// coordinates depend on the resolution mode of the camera, but also require doubling in the X-axis
			
			Rectangle r = FrameRectangle;
			
			// Tracking box
			g.DrawRectangle( SystemPens.ControlDarkDark, r );
			
			Brush objectBrush = new SolidBrush( TrackColor );
			Brush centreBrush = TrackColor.GetBrightness() > 0.5 ? Brushes.Black : Brushes.White;
			
			Rectangle trackingRectangle = TransformRect( p.Rectangle );
			Point     centroid          = TransformPoint( p.Centroid );
			
			g.FillRectangle( objectBrush, trackingRectangle );
			g.FillRectangle( centreBrush, centroid.X - 1, centroid.Y - 1, 3, 3 );
			
			//////////////////////////////////////////////
			
			if( p2 != null ) {
				
				int y=0;
				foreach(TPacketM2Row row in p2.Rows) {
					
					Rectangle line = TransformRect( new Rectangle(  row.Min, y, row.Max - row.Min, 1 ) );
					Rectangle avg  = TransformRect( new Rectangle( row.Mean, y,                 1, 1 ) );
					
					g.FillRectangle( Brushes.Orange, line );
					g.FillRectangle( Brushes.White , avg  );
					
					// TODO: display confidence and pixel count?
					
					y++;
				}
				
			} else if( p1 != null ) {
				
				using(Bitmap bmp = p1.ToBitmap()) {
					
					g.DrawImage( bmp, FrameRectangle );
				}
				
			}
			
			String text = String.Format("Confidence: {0}\nPixel Count: {1}", p.Confidence, p.PixelCount);
			g.DrawString( text, SystemFonts.IconTitleFont, SystemBrushes.ControlText, 5, r.Y + r.Height + 5 );
		}
		
		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			
			Invalidate();
		}
		
	}
}
