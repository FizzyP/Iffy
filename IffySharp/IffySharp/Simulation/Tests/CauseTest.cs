using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Simulation;

namespace IffySharp.Tests
{
    class CauseTest
    {
        public static void test()
        {
            var vc = new ValueCause<double>(3.141592);
            var vcc = new ValueCloneCause(vc);

            Console.WriteLine("vcc.Value = " + vcc.Value);
            vc.Value = 2.718281828;
            Console.WriteLine("vc.Value = " + vc.Value);
            Console.WriteLine("vcc.Value = " + vcc.Value);

            var vc2 = new ValueCause<double>(-1.718281828);
            var sumCause = new BinOpCause<double>((double x, double y) => { return x + y; }, vc, vc2);
            Console.WriteLine("vc2 = " + vc2.Value);
            Console.WriteLine("sum of vc2 and vc = " + sumCause.Value);
        }


        class ValueCloneCause : ValueCause<double>
        {
            ValueCause<double> cloneMe;

            public ValueCloneCause(ValueCause<double> cloneMe)
                : base(cloneMe.Value)
            {
                this.cloneMe = cloneMe;
                //  Get an update when cloneMe changes.
                this.addDependency(cloneMe);
                this.update();
            }

            public override void onUpdate()
            {
                _value = cloneMe.Value;
            }

        }
    }
}
