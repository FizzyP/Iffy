using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
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
			DateTime time = Time;
			time.AddSeconds(dtSeconds);
			Time = time;	//	trigger the cause
		}

		public TimeCause(DateTime startTime)
        : base(startTime)
        {
        }

    }
}
