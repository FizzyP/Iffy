
using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation.Actions
{
	public class MaterliazationEvent : WorldEvent
	{
//		private readonly object kMaterliazedObjectKey = new object();

		public MaterliazationEvent (WorldObjectBase materializedObject)
		{
			InternalDescription = "(object materialized)";
			SensibleAspect.imbue(this, "");
		}
	}
}

