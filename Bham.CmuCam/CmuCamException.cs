using System;
using System.Runtime.Serialization;

namespace Bham.CmuCam {
	
	/// <summary>The exception that is thrown when an error is encountered when communicating with the CMUcam2 camera.</summary>
	[Serializable]
	public class CmuCamException : Exception {
		
		/// <summary>Initializes a new instance of the CmuCamException class.</summary>
		public CmuCamException() { }
		
		/// <summary>Initializes a new instance of the CmuCamException class with the specified error message.</summary>
		public CmuCamException(string message) : base(message) { }
		
		/// <summary>Initializes a new instance of the CmuCamException class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		public CmuCamException(string message, Exception inner) : base(message, inner) { }
		
		/// <summary>Initializes a new instance of the CmuCamException class with serialized data.</summary>
		protected CmuCamException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
	
}
