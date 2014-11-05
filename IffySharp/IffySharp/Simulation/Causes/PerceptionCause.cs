using System;

using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	abstract
	public class PerceptionCause : Cause
	{
		abstract
		public void onEvent (WorldEvent we);

		private readonly ValueCause<string> innerMonologue = new ValueCause<string>("");

		public RValueCause<string> InnerMonologue {
			get {
				return innerMonologue;
			}
		}

		EventCause worldEvents;

		public PerceptionCause (EventCause worldEvents)
		{
			this.worldEvents = worldEvents;
			this.addDependency (worldEvents);
			IsLazy = false;
			IsDirty = false;
			InnerMonologue.IsLazy = false;
		}

		override
		public void onUpdate()
		{
			onEvent (worldEvents.Value);
		}

	}
}

