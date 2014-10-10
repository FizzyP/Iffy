using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.W

namespace IffySharp.Simulation.Aspects
{

    public class MapLocation
    {
        public int x, y, z;
        public int 
    }

    class MapLocationCause : FunctionCause<MapLocation>
    {
        public MapLocationCause(FunctionCauseGetter<MapLocation> function)
            : base(function)
        { }
    }

    abstract class MapLocationAspect
    {
        public static readonly Object kMapLocationKey = new Object();

        public static WorldObjectBase imbue(WorldObjectBase obj,  FunctionCauseGetter<MapLocation> function)
        {
            obj[kMapLocationKey] = new MapLocationCause(function);
            return obj;
        }
    }
}
