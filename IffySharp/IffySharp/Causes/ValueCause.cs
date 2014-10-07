using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp
{
    class ValueCause<T> : Cause
    {
        public ValueCause(T initialValue)
        {
            _value = initialValue;
        }

        private T _value;
        public T Value
        {
            set
            {
                _value = value;
                IsDirty = true;
                update();
            }
            get
            {
                return _value;
            }
        }

        public override void onUpdate()
        {
            //  Do nothing
        }
    }
}
