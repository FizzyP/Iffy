using System;

namespace IffySharp.Simulation
{
	abstract
	public class PerceptionCause : Cause
	{
		abstract
		public void onEvent (WorldEvent we);

		EventCause worldEvents;

		public PerceptionCause (EventCause worldEvents)
		{
			this.worldEvents = worldEvents;
			this.addDependency (worldEvents);
			IsLazy = false;
			IsDirty = false;
		}

		override
		public void onUpdate()
		{
			onEvent (worldEvents.Value);
		}

	}
}

