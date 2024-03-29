﻿using System;

namespace IffySharp.Simulation
{
	abstract
	public class PerceptionCause : Cause
	{
		//	Override this to create any hearing behaviors you want.
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

