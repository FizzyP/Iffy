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
			: base (EventAspect.getCause ( MapLocationAspect.getMapLocationState(player).world))
		{
			IsLazy = false;
			this.player = player;
			this.Knowledge = KnowledgeAspect.getKnowledge (player);
		}

		override
		public void onEvent(WorldEvent worldEvent)
		{
			//	Default:
			//	Hack just to get something on the screen.
			string printMe = worldEvent.InternalDescription;

			//	Look for a better description

			/*
			var sense = SensibleAspect.getInterpretations (worldEvent);
			if (sense != null) {
				foreach (var sensation in sense) {
					var desription = DescriptionAspect.getDescription (SensationInterpretation.kCompositeSensationKey, sensation);
					if (desription != null) {
						printMe = desription.get(player, sensation);
						break;
					}
				}
			}
			*/

			SensationInterpretation sensation;
			var descr = SensibleAspect.getInterpretationDescription (worldEvent, PlayerSensationChooser, out sensation);
			if (descr != null)
				printMe = descr.get (player, sensation, PlayerSensationChooser);

			this.InnerMonologue.Value = printMe;

			//	Determine if the event is perceived (assume yes for now)
			//	Determine consequences of perception

			SymbolicKnowledge newKnowledge = KnowledgeAspect.getKnowledge (player);
			if (newKnowledge != null) {
				learn(newKnowledge);
			}
		}


		public static readonly SensationInterpretationChooser PlayerSensationChooser = new SensationInterpretationChooser(playerSensationInterpeter);

		static
		private SensationInterpretation playerSensationInterpeter(SensationInterpretation[] sensations)
		{
			foreach (var sensation in sensations) {
				var desription = DescriptionAspect.getDescription (SensationInterpretation.kCompositeSensationKey, sensation);
				if (desription != null) {
					return sensation;
				}
			}
			return null;
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

