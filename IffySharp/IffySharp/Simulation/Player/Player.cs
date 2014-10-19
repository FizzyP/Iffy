using System;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	public class Player : WorldObjectBase
	{
		public Player (WorldBlock start)
		{
			var startLoc = MapLocationAspect.getMapLocationState (start);
			MapLocationAspect.imbue (this, startLoc);
			var perception = new PlayerPerceptionCause (this);
			PerceptionAspect.imbue (this, perception);
		}
	}
}

