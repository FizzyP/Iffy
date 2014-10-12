using System;

namespace IffySharp.Simulation
{
	abstract
	public class HearingCause : Cause
	{
		//	Override this to create any hearing behaviors you want.
		abstract
		public void onSound (SoundEventData sound);



		SoundCause worldSoundCause;

		public HearingCause (SoundCause worldSound)
		{
			worldSoundCause = worldSound;
			this.addDependency (worldSoundCause);
			IsLazy = false;
			IsDirty = false;
		}

		override
		public void onUpdate()
		{
			onSound (worldSoundCause.Value);
		}


	}

}

