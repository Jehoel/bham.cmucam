using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace CmuCam2Gui {
	
	public partial class BitmapEditor : Control {
		
		private Byte[,] bitmap = new Byte[8,8];
		
		public BitmapEditor() {
			InitializeComponent();
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
		
		
		
		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);
			
			Graphics g = pe.Graphics;
			
			
			
		}
	}
}
