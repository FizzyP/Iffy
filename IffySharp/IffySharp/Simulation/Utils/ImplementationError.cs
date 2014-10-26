using System;

namespace IffySharp
{
	public class ImplementationError : Exception
	{
		public ImplementationError()
		{}

		public ImplementationError (string msg) : base(msg)
		{
		}
	}
}

