using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class TimeCause : ValueCause<double>
    {
        public double Time
        {
            set { Value = value;  }
            get { return Value; }
        }

        public TimeCause(double startTime)
        : base(startTime)
        {
        }

    }
}
