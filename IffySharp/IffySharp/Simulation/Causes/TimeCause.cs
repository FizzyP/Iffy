using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class TimeCause : ValueCause<DateTime>
    {
		public DateTime Time
        {
            set { Value = value;  }
            get { return Value; }
        }

		public advanceTime(double dtSeconds)
		{
			DateTime time = Time;
			time.AddSeconds(dtSeconds);
			Time = time;
		}

		public TimeCause(DateTime startTime)
        : base(startTime)
        {
        }

    }
}
