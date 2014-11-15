using System;

namespace IffySharp.Simulation.Aspects
{
	public class FallingEvent : WorldEvent
	{
		public FallingEvent ()
		{
			InternalDescription = "(object fell)";

			SensibleAspect.imbue (this, "Soething is falling.");
		}
	}
}

