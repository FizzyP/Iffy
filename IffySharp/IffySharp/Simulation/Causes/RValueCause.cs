using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
//  Read-Only Value Cause
//

namespace IffySharp.Simulation
{
    public class RValueCause<T> : Cause
    {
        public RValueCause(T initialValue)
        {
            _value = initialValue;
            IsDirty = false;
        }

        public RValueCause()
        {
            IsDirty = false;
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
