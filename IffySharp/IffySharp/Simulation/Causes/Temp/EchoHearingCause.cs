using System;

namespace IffySharp.Simulation
{
	public class EchoHearingCause : HearingCause
	{
		public EchoHearingCause (SoundCause worldSound)
			: base(worldSound)
		{
		}

		override
		public void onSound (SoundEventData sound)
		{
			Console.WriteLine (sound.volume);
		}

	}
}

