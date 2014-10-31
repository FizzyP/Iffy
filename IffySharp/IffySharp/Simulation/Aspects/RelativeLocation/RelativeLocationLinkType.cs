using System;

namespace IffySharp.Simulation.Aspects
{
	abstract
	public class RelativeLocationLinkType
	{
		public RelativeLocationLinkType ()
		{
		}
	}

	public class NoConnectionLinkType : RelativeLocationLinkType
	{
		public static readonly NoConnectionLinkType _ = new NoConnectionLinkType();
	}

}

