using System;

namespace IffySharp.SubParser
{
	public class SymbolicToken
	{
		public readonly string Name;

		public SymbolicToken (string name)
		{
			Name = name;
		}

		override
		public string ToString()
		{
			return Name;
		}
	}


}

