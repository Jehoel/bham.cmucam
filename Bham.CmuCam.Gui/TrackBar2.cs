using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bham.CmuCam.Gui {
	
	/// <summary>Trackbar with a ScrollStopped event that fires only when a value has been chosen.</summary>
	public class TrackBar2 : TrackBar {
		
		private int _lastStoppedOn = 0;
		
		public TrackBar2() : base() {
			
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}
		
		protected override void WndProc(ref Message m) {
			
			base.WndProc(ref m);
			
			if( (m.Msg == 0x2115 || m.Msg == 0x2114) && (int)m.WParam == 8 ) {
				
				if( Value == _lastStoppedOn ) return;
				_lastStoppedOn = this.Value;
				
				OnScrollStopped(EventArgs.Empty);
			}
			
		}
		
		protected void OnScrollStopped(EventArgs e) {
			
			if( ScrollStopped != null ) {
				
				ScrollStopped(this, e);
			}
		}
		
		public event EventHandler ScrollStopped;
	}
}
