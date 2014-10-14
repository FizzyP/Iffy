using System;

namespace IffySharp.Simulation
{
	public class EventCause : ValueCause<WorldEvent>
	{
		public EventCause ()
		{
			//	An event with no event to report is clean.  If it is marked dirty
			//	then it will generate a non-event every time anyone adds it as a dependency.
			IsDirty = false;
		}
	}
}

