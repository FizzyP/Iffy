using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    interface IWorldMap
    {
        //  Get a completely formed block.
        WorldBlock getBlock(IntVector3 spot);

        //  Get a (possibly) partially formed block.  This is to be used
        //  by an IBlockConfigurator to lazy-fill the map.
        WorldBlock peekBlock(IntVector3 spot);
    }
}
