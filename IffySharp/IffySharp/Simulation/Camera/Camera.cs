using System;

using IffySharp;
using IffySharp.Simulation;

namespace IffySharp.Simulation
{
	public class Camera : Cause
	{
		private IIffyRenderer renderer;
		private EventCause eventCause;

		public Camera (IIffyRenderer renderer, EventCause eventCause)
		{
			IsRecording = false;
			this.renderer = renderer;
			this.eventCause = eventCause;

			IsLazy = false;					//	report events as soon as they happen.
			addDependency (eventCause);
		}

		public bool IsRecording {
			get;
			set;
		}

		override
		public void onUpdate()
		{
			//	We're dependent on just "eventCause" so if we're updated it's because
			//	a new event has occurred.  Fetch it from the cause.
			var worldEvent = eventCause.Value;
			renderer.render (worldEvent.InternalDescription);
		}
	}
}

