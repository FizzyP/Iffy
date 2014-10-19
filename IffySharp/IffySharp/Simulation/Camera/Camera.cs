using System;

using IffySharp;
using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	public class Camera : Cause
	{
		private IIffyRenderer renderer;
		private RValueCause<string> messageCause;

		private Camera (IIffyRenderer renderer, RValueCause<string> messageCause)
		{
			IsRecording = false;
			this.renderer = renderer;
			this.messageCause = messageCause;

			IsLazy = false;					//	report events as soon as they happen.
			addDependency (messageCause);
		}

		public static Camera new_FollowingObject(WorldObjectBase obj, IIffyRenderer renderer)
		{
			var perception = PerceptionAspect.getPerceptionCause (obj);
			if (perception == null)
				throw new ArgumentException ("A camera must be built from objects imbued with perception.");
			var messages = perception.InnerMonologue;

			//	Hook up a new camera listening to messages and publishing to renderer.
			return new Camera (renderer, messages);
		}

		public bool IsRecording {
			get;
			set;
		}

		override
		public void onUpdate()
		{
			renderer.render (messageCause.Value);
		}
	}
}

