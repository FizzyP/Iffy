using System;

namespace IffySharp.Simulation.Aspects
{
	public class SoundAspect
	{
		public SoundAspect ()
		{
		}

		public static readonly Object kSoundKey = new Object();

		public static WorldObjectBase imbue(WorldObjectBase obj)
		{
			obj[kSoundKey] = new SoundCause();
			return obj;
		}

		public static SoundCause getSoundCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kSoundKey))
				return null;
			else
				return (SoundCause) obj [kSoundKey];
		}

	}
}

