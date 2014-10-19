using System;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	public class PlayerPerceptionCause : PerceptionCause
	{
		public PlayerPerceptionCause (Player player)
			: base (EventAspect.getEventCause ( MapLocationAspect.getMapLocationState(player).world))
		{
			IsLazy = false;
		}

		override
		public void onEvent(WorldEvent worldEvent)
		{
			//	Hack just to get something on the screen.
			this.InnerMonologue.Value = worldEvent.InternalDescription;
		}
	}
}

