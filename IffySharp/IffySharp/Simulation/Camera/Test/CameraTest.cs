using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;
using IffySharp.StdLib;

namespace IffySharp.Simulation.Test
{
	abstract
	public class CameraTest
	{

		public static void test()
		{
			var world = new World (new ConstantBlockConfigurator());
			var block = world.getBlock (World.center);
			var eventCause = EventAspect.getCause (world);

			var player = new Player (block);

			var camera = Camera.new_FollowingObject(player, new SimpleRenderer());

			//	Generate a new sound
			var we = new WorldEvent ();
			we.InternalDescription = "(some world event)";
			eventCause.Value = we;
		}
	}
}

