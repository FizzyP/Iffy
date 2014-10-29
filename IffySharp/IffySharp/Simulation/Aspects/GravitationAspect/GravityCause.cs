using System;
using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class GravityCause : Cause
	{
		MapLocationCause locCause;
		RelativeLocationCause relLocCause;

		public GravityCause (WorldObjectBase target)
		{
			locCause = MapLocationAspect.getCause (target);
			if (locCause == null)
				throw new ArgumentException ("Target must possess map location aspect.");
			addDependency (locCause);

			relLocCause = RelativeLocationAspect.getCause (target);
			if (relLocCause == null)
				throw new ArgumentException ("Target must possess relative location aspect.");
			addDependency (relLocCause);
		}

		override
		public void onUpdate()
		{
		}
	}
}

