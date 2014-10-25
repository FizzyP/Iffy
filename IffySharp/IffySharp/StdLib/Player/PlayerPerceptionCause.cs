using System;
using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;

namespace IffySharp.StdLib
{
	public class PlayerPerceptionCause : PerceptionCause
	{
		Player player;
		public readonly SymbolicKnowledge Knowledge;

		public PlayerPerceptionCause (Player player)
			: base (EventAspect.getEventCause ( MapLocationAspect.getMapLocationState(player).world))
		{
			IsLazy = false;
			this.player = player;
			this.Knowledge = KnowledgeAspect.getKnowledge (player);
		}

		override
		public void onEvent(WorldEvent worldEvent)
		{
			//	Hack just to get something on the screen.
			this.InnerMonologue.Value = worldEvent.InternalDescription;

			SymbolicKnowledge newKnowledge = KnowledgeAspect.getKnowledge (player);
			if (newKnowledge != null) {
				learn(newKnowledge);
			}
		}


		//////////////////////////////////////////
		/// 
		/// Private
		/// 

		private void learn(SymbolicKnowledge newKnowledge)
		{
			if (Knowledge != null)
				Knowledge.addAll (newKnowledge);
		}
	}
}

