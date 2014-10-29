using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation.Aspects
{

    abstract
	class MapLocationAspect
    {
        public static readonly Object kMapLocationKey = new Object();

        public static WorldObjectBase imbue(WorldObjectBase obj,  MapLocationState initialState)
        {
            obj[kMapLocationKey] = new MapLocationCause(initialState);
            return obj;
        }

		public static WorldObjectBase imbue(WorldObjectBase obj, IntVector3 gridPosition, World world)
        {
            var initialState = new MapLocationState();
            initialState.position = gridPosition;
            initialState.velocity = new Vector3(0,0,0);
			initialState.world = world;

            obj[kMapLocationKey] = new MapLocationCause(initialState);
            return obj;
        }

		public static MapLocationCause getCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kMapLocationKey))
				return null;
			else
				return (MapLocationCause) obj [kMapLocationKey];
		}

		public static MapLocationState getMapLocationState(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kMapLocationKey))
				return null;
			else
				return ((MapLocationCause) obj [kMapLocationKey]).Value;
		}

	}
}
