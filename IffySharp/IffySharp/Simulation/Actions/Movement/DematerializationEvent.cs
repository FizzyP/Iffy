using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation.Actions
{
	public class DematerializationEvent : WorldEvent
	{
		public readonly WorldObjectBase DematerializedObject;

		public DematerializationEvent (WorldObjectBase obj)
		{
			DematerializedObject = obj;
			InternalDescription = "(object dematerialized)";

			SensibleAspect.imbue (this, SensibleAspect.getInterpretationDescription( " disappears.");
		}
	}
}

