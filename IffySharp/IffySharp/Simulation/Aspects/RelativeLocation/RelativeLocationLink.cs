using System;

using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class RelativeLocationLink
	{
		public readonly Preposition preposition;
		public readonly RelativeLocationLinkType linkType;

		public RelativeLocationLink(Preposition p, RelativeLocationLinkType t)
		{
			preposition = p;
			linkType = t;
		}


		//
		//	NoLink
		//

		private static RelativeLocationLink _NoLink;

		public static RelativeLocationLink NoLink {
			get {
				return _NoLink ?? new RelativeLocationLink (NoPreposition._, NoConnectionLinkType._);
			}
		}
	}
}

