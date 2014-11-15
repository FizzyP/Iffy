using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.StdLib
{
	public class TestBlockConfigurator : AbstractBlockConfigurator
	{
		public TestBlockConfigurator ()
		{
		}

		override
		public void configure(WorldBlock block, World world)
		{
			//	Assume blocks have map location aspect
			var locState = MapLocationAspect.getMapLocationState (block);

			if (locState.position.z >= 10) {
				configureAsAir (block, world);

			} else {
				configureAsGround (block, world, locState);
			}
		}

		static void configureAsGround(WorldBlock block, World world, MapLocationState locState)
		{
			block.IsSolid.Value = true;
		}

		static void configureAsAir(WorldBlock block, World world)
		{
			block.IsSolid.Value = false;
		}

	}
}

