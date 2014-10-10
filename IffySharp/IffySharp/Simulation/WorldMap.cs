using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class WorldMapArray : IWorldMap
    {
        static readonly IntVector3 dim = new IntVector3(100, 100, 20);
        static readonly IntVector3 center = new IntVector3(50, 50, 10);

        WorldBlock[, ,] blocks = new WorldBlock[dim.x, dim.y, dim.z];
        WorldBlock defaultBlock;    //  All undefined blocks map to this

        WorldMapArray()
        {

        }

        public WorldBlock getBlock(IntVector3 spot)
        {
            //  Spot is in relative coordinates.  Move to absolute
            spot = spot + center;

            if (spot.x < 0 || spot.x >= dim.x ||
                spot.y < 0 || spot.y >= dim.y ||
                spot.z < 0 || spot.z >- dim.z)
            {
                return defaultBlock;
            }
            else {
                var block = blocks[spot.x, spot.y, spot.z];
                if (block == null)
                {
                    block = new WorldBlock();
                    blocks[spot.x, spot.y, spot.z] = block;
                }
                return block;
            }
        }

    }
}
