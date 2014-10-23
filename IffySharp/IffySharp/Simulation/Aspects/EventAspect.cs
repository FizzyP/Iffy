using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class EventAspect
	{
		private static readonly Object kEventKey = new Object();

		public static WorldObjectBase imbue(WorldObjectBase obj)
		{
			obj[kEventKey] = new EventCause();
			return obj;
		}

		public static EventCause getEventCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kEventKey))
				return null;
			else
				return (EventCause) obj [kEventKey];
		}
	}
}

