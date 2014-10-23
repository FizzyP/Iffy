using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class PerceptionAspect
	{
		private static readonly Object kEventListeningKey = new Object();

		public static WorldObjectBase imbue (WorldObjectBase obj, PerceptionCause perception)
		{
			var objLoc = MapLocationAspect.getMapLocationState (obj);

			if (objLoc == null)
				throw new Exception ("Cannot imbue an object with perception if it has no physical location.");

			//	Remember the hearing cause
			obj [kEventListeningKey] = perception;

			//	Hook it up to listen to the world
			EventCause worldEvents = EventAspect.getEventCause (objLoc.world);
			perception.addDependency (worldEvents);

			return obj;
		}

		public static PerceptionCause getPerceptionCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kEventListeningKey))
				return null;
			else
				return (PerceptionCause) obj [kEventListeningKey];
		}
	}
}

