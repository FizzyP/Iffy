using System;

using IffySharp.Simulation;


namespace IffySharp.Simulation.Test
{
	public class WorldTest
	{
		public WorldTest ()
		{
		}

		public static void test()
		{
			var world = new World (new ConstantBlockConfigurator());

			var spot = new IntVector3 (0, 0, 0);
			var block = world.getBlock (spot);
		}
	}
}

