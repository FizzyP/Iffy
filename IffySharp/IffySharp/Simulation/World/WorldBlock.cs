using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    public class WorldBlock : WorldObjectBase
    {
		public ValueCause<bool> IsSolid = new ValueCause<bool>(false);
    }
}
