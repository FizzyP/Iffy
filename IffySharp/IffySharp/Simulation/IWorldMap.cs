using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    interface IWorldMap
    {
        WorldBlock getBlock(IntVector3 spot);
    }
}
