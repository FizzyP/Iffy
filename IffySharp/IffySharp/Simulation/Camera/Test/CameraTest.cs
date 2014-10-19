using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation.Test
{
	abstract
	public class CameraTest
	{

		public static void test()
		{
			var world = new World (new ConstantBlockConfigurator());
			var spot = new IntVector3 (0, 0, 0);
			var block = world.getBlock (spot);
			var eventCause = EventAspect.getEventCause (world);
			var camera = new Camera (new SimpleRenderer(), eventCause);

			//	Generate a new sound
			var we = new WorldEvent ();
			we.InternalDescription = "(some world event)";
			eventCause.Value = we;
		}
	}
}

