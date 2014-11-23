using System;
using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.StdLib
{
	public class Player : WorldObjectBase
	{
		public Player (WorldBlock start)
		{
			//
			//	Physical
			//
			var startLoc = MapLocationAspect.getMapLocationState (start);
			MapLocationAspect.imbue (this, startLoc);
			RelativeLocationAspect.imbue (this);
			GravityAspect.imbue (this);

			//
			//	Perceptual
			//
			var perception = new PlayerPerceptionCause (this);
			PerceptionAspect.imbue (this, perception);
			KnowledgeAspect.imbue (this);

		}
	}
}

