using System;

using IffySharp;
using IffySharp.Simulation;

namespace IffySharp.Simulation
{
	public class Camera : PerceptionCause
	{
		public ValueCause<string> InnerMonologue {
			set;
			get;
		}

		private IIffyRenderer renderer;

		public Camera (IIffyRenderer renderer, EventCause eventCause)
			: base(eventCause)
		{
			InnerMonologue = new ValueCause<string> ();

			IsRecording = false;
			this.renderer = renderer;

			IsLazy = false;					//	report events as soon as they happen.
			addDependency (eventCause);
		}

		public bool IsRecording {
			get;
			set;
		}

		override
		public void onEvent (WorldEvent worldEvent)
		{
			renderer.render (worldEvent.InternalDescription);
		}
	}
}

