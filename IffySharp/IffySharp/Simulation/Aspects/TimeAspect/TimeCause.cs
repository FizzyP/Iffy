using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation.Aspects
{
    public class TimeCause : ValueCause<DateTime>
    {
		public DateTime Time
        {
            set { Value = value;  }
            get { return Value; }
        }

		public void advanceTime(double dtSeconds)
		{
			DateTime time = Time.AddSeconds(dtSeconds);

			//	Clean up the queue
			doQueuedCauses (time);

			//	Update the time cause itself if anything is listening to it directly
			Time = time;	//	trigger the cause
		}

		public TimeCause(DateTime startTime)
        : base(startTime)
        {
        }

		//	
		//	Event Queue
		//

		//	DateTime ticks are long
		private SortedDictionary<long, List<Cause>> eventQueue = new SortedDictionary<long, List<Cause>>();

		public void enqueueCause(DateTime atTime, Cause cause)
		{
			long time = atTime.Ticks;
			if (!eventQueue.ContainsKey (time)) {
				eventQueue [time] = new List<Cause> ();
			}

			eventQueue [time].Add (cause);
		}

		void doQueuedCauses(DateTime untilTime)
		{
			long untilTicks = untilTime.Ticks;

			//	Copy to avoid concurrent modification problems.
			var eventQueueCopy = new SortedDictionary<long, List<Cause>> (eventQueue);

			foreach (KeyValuePair<long, List<Cause>> kv in eventQueueCopy) {
				DateTime causeTime = new DateTime (kv.Key);
				if (kv.Key > untilTicks)
					break;

				//	Advance time to this point and invoke the cause
				Time = new DateTime (kv.Key);

				//	The causes in the queue don't listen to Time directly.
				//	Instead they are marked dirty here.  If they are also !IsLazy then
				//	this will cause them to "occurr".
				foreach (Cause cause in kv.Value) {
					cause.IsDirty = true;
				}
			}
		}

    }
}
