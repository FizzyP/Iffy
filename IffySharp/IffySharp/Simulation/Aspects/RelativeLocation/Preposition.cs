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


	public class NoPreposition : Preposition
	{
		public static readonly NoPreposition _ = new NoPreposition();
	}

	public class OnPreposition : Preposition
	{
		public static readonly OnPreposition _ = new OnPreposition();
	}
}

