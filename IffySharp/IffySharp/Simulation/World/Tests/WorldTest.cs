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


			var sound = SoundAspect.getSoundCause (world);

			//	Make block listen?
			HearingAspect.imbue (block, new EchoHearingCause(sound));

			//	Generate a new sound

			sound.Value = new SoundEventData (100);
		}
	}
}

