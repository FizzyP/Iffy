using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class TimeAspect
	{
		public static readonly Object kTimeKey = new Object();

		public static WorldObjectBase imbue(WorldObjectBase obj)
		{
			obj[kTimeKey] = new TimeCause(DateTime.Now);
			return obj;
		}

		public static TimeCause getTimeCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kTimeKey))
				return null;
			else
				return (TimeCause) obj [kTimeKey];
		}

	}
}

