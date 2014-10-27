using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    [Serializable]
    public class WorldState
    {
		public readonly List<World> worlds = new List<World>();
    }
}
