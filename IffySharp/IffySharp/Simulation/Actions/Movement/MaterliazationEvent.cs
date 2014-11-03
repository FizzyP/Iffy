
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

			SensibleAspect.imbue(this, "");
		}
	}
}

