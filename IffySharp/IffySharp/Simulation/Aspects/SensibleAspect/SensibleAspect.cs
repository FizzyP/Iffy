using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class SensibleAspect
	{
		private static readonly Object kSensationKey = new Object();

		//	Naive constructor just to get us off the ground
		public static WorldObjectBase imbue(WorldObjectBase obj, string description)
		{
			var interpretation = SensationInterpretation.new_compositeFromString (description);
			obj [kSensationKey] = interpretation;
			return obj;
		}

		public static SensationInterpretation[] getInterpretations(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kSensationKey))
				return null;
			else
				return (SensationInterpretation[]) obj [kSensationKey];
		}
	}
}

