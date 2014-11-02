using System;

namespace IffySharp.SubParser
{
	public class InvalidDispatchException : Exception
	{
		public InvalidDispatchException ()
		{
		}
		public InvalidDispatchException (string message)
			: base("InvalidDispatch: " + message)
		{
		}
	}
}

