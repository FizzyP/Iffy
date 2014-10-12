using System;

namespace IffySharp.Simulation
{
	public class SoundEventData
	{
		public readonly double volume;

		public SoundEventData(double volume)
		{
			this.volume = volume;
		}

		public static readonly SoundEventData Silence = new SoundEventData(0);
	}

	public class SoundCause : ValueCause<SoundEventData>
	{
		public SoundCause ()
			: base (SoundEventData.Silence)
		{
//			Value = SoundEventData.Silence;
		}
	}
}

