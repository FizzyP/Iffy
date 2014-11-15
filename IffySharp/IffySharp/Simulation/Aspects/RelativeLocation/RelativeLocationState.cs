using System;
using System.Collections.Generic;

using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class RelativeLocationState : Dictionary<WorldObjectBase, RelativeLocationLinkCause>
	{
		public RelativeLocationState ()
		{
		}
	}
}

