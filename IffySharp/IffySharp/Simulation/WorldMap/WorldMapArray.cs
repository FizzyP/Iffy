using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
    class WorldMapArray : IWorldMap
    {
        static readonly IntVector3 dim = new IntVector3(100, 100, 20);
        static readonly IntVector3 center = new IntVector3(50, 50, 10);

        WorldBlock[, ,] blocks = new WorldBlock[dim.x, dim.y, dim.z];
        WorldBlock defaultBlock;    //  All undefined blocks map to this

        IBlockConfigurator configurator;

        WorldMapArray(IBlockConfigurator blockConfig)
        {
            configurator = blockConfig;
        }

        public WorldBlock peekBlock(IntVector3 spot)
        {
            if (spot.x < 0 || spot.x >= dim.x ||
                spot.y < 0 || spot.y >= dim.y ||
                spot.z < 0 || spot.z > -dim.z)
            {
                return null;
            }
            var block = blocks[spot.x, spot.y, spot.z];
            if (block == null) {
                block = blocks[spot.x, spot.y, spot.z] = new WorldBlock();
				//  Put the block in the spot
				MapLocationAspect.imbue(block, spot);
            }
            return block;
        }


        public WorldBlock getBlock(IntVector3 spot)
        {
            WorldBlock block = peekBlock(spot);

            if (block == null)
                return defaultBlock;

            //  Do custom configuration
            configurator.configure(block, this);

            return block;
        }

    }
}
