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
			//	Description delegate just returns the given string.
			var interpretation = SensationInterpretation.new_composite (
				(WorldObjectBase to, WorldObjectBase of)
					=> description
			);

			if (!obj.hasAttribute (kSensationKey)) {
				obj [kSensationKey] = new SensationInterpretation[1];
			}

			((SensationInterpretation[]) obj [kSensationKey])[0] = interpretation;
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

