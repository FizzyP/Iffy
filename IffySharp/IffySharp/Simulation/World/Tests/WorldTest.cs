using System;

using IffySharp.Simulation;


namespace IffySharp
{
	public class WorldTest
	{
		public WorldTest ()
		{
		}

		public static void test()
		{
			var world = new World (new ConstantBlockConfigurator());
		}
	}
}

