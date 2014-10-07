using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("vcc.Value = " + vcc.Value);
        }


        class ValueCloneCause : Cause
        {
            ValueCause<double> cloneMe;

            double _value;
            public double Value
            {
                get
                {
                    return _value;
                }
            }

            public ValueCloneCause(ValueCause<double> cloneMe)
            {
                this.cloneMe = cloneMe;
                this._value = cloneMe.Value;

                //  Get an update when cloneMe changes.
                this.addDependency(cloneMe);
            }

            public override void onUpdate()
            {
                _value = cloneMe.Value;
            }

        }
    }
}
