using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class RValueCause<T> : Cause
    {
        public RValueCause(T initialValue)
        {
            _value = initialValue;
            IsDirty = false;
        }

        public RValueCause()
        {
            IsDirty = true;
        }

        protected T _value;

        virtual
        public T Value
        {
            get
            {
                update();
                return _value;
            }
            set
            {
                //  Does nothing at all
            }
        }

        public override void onUpdate()
        {
            //  Do nothing
        }
    }
}
