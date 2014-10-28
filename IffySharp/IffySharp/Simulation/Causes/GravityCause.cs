using System;

using IffySharp;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	public class GravityCause : Cause
	{
		public GravityCause (WorldObjectBase target)
		{
			var locCause = MapLocationAspect.getMapLocationCause (target);
			if (locCause == null)
				throw new ArgumentException ("Target must possess map location aspect.");
		}

		override
		public void onUpdate()
		{
		}
	}


}

