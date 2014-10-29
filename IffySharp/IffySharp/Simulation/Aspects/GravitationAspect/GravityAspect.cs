using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class GravityAspect
	{
		private static readonly Object kGravityKey = new Object();

		public static WorldObjectBase imbue(WorldObjectBase obj)
		{
			obj[kGravityKey] = new GravityCause(obj);
			return obj;
		}

		public static GravityCause getGravityCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kGravityKey))
				return null;
			else
				return (GravityCause)obj [kGravityKey];
		}

	}
}

