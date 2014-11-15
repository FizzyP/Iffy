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

	public class SurfaceContactLinkType : RelativeLocationLinkType
	{
		public static readonly SurfaceContactLinkType _ = new SurfaceContactLinkType();
	}

}

