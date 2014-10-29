using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;


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

			var eventCause = EventAspect.getCause (world);

			//	Make block listen?
			PerceptionAspect.imbue (block, new EchoPerceptionCause(eventCause));

			//	Generate a new sound
			eventCause.Value = new WorldEvent ();
		}
	}
}

