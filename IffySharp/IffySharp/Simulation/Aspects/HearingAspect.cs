using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class HearingAspect : Cause
	{
		public static readonly Object kHearingKey = new Object();

		public static WorldObjectBase imbue(WorldObjectBase obj, HearingCause hearingCause)
		{
			var objLoc = MapLocationAspect.getMapLocationState (obj);

			if (objLoc == null)
				throw new Exception ("Cannot imbue an object with hearing if it has no physical location.");

			//	Remember the hearing cause
			obj[kHearingKey] = hearingCause;

			//	Hook it up to listen to the world
			SoundCause worldSound = SoundAspect.getSoundCause(objLoc.world);
			hearingCause.addDependency (worldSound);

			return obj;
		}

	}
}

