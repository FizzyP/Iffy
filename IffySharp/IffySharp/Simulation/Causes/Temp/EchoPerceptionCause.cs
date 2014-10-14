using System;

namespace IffySharp.Simulation
{
	public class EchoPerceptionCause : PerceptionCause
	{
		public EchoPerceptionCause (EventCause events)
			: base(events)
		{
		}

		override
		public void onEvent (WorldEvent we)
		{
			Console.WriteLine ("hi");
		}

	}
}

