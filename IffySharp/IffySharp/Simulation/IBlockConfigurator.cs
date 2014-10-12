using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    interface IBlockConfigurator
    {
        void configure(WorldBlock block, World world);
    }
}
