using System;

namespace IffySharp.Simulation.Aspects
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

