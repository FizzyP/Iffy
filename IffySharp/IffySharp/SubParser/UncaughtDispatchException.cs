using System;

namespace IffySharp
{
	public class UncaughtDispatchException : Exception
	{
		public UncaughtDispatchException ()
			: base("Uncaught dispatch.")
		{
		}
	}
}

