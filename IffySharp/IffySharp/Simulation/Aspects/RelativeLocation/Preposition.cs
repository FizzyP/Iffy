using System;

namespace IffySharp
{
	abstract
	public class Preposition
	{
		public Preposition ()
		{
		}
	}



	public class OnPreposition : Preposition
	{
		public static readonly OnPreposition _ = new OnPreposition();
	}
}

