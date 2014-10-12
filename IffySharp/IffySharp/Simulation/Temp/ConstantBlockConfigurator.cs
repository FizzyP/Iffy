using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
    abstract class ConstantBlockConfigurator
    {
        static public void configure(WorldBlock block, World world)
        {
			//	Assume blocks have map location aspect
			var locState = MapLocationAspect.getMapLocationState (block);

			if (locState.position.x > 10) {
				configureAsAir (block, world);
			} else {
				configureAsGround (block, world);
			}
        }



		static void configureAsGround(WorldBlock block, World world)
		{
		}

		static void configureAsAir(WorldBlock block, World world)
		{
		}

	
	}
}
