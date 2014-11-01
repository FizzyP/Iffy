using System;


namespace IffySharp.Simulation.Aspects
{
	abstract
	public class RelativeLocationAspect
	{
		private static readonly Object kRelLocKey = new Object();

		public static WorldObjectBase imbue(WorldObjectBase obj)
		{
			obj[kRelLocKey] = new RelativeLocationCause();
			return obj;
		}

		public static RelativeLocationCause getCause(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kRelLocKey))
				return null;
			else
				return (RelativeLocationCause) obj [kRelLocKey];
		}
	}
}

