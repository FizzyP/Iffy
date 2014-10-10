using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class ValueCause<T> : RValueCause<T>
    {
        public ValueCause(T initialValue)
            : base(initialValue)
        {
        }

        public ValueCause()
            : base()
        {
        }

        override
        public T Value
        {
            set
            {
                _value = value;
                IsDirty = true;
            }
            get
            {
                update();
                return _value;
            }
        }

        public static implicit operator ValueCause<T>(T t)
        {
            return new ValueCause<T>(t);
        }
    }
}
