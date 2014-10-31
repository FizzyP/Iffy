using System;

using System.Collections.Generic;

namespace IffySharp.Simulation.Aspects
{
	public class RelativeLocationLink
	{
		public Preposition preposition;
		public RelativeLocationLinkType linkType;
	}

	public class RelativeLocationState : Dictionary<WorldObjectBase, RelativeLocationLink>
	{
		public RelativeLocationState ()
		{
		}
	}
}

