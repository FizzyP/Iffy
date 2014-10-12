using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{

    public delegate T FunctionCauseGetter<T>();

    class FunctionCause<T> : ValueCause<T>
    {

        FunctionCauseGetter<T> getter;

        //public FunctionCause(FunctionCauseGetter<T> getter)
        //{
        //    this.getter = getter;
        //}

        public FunctionCause(FunctionCauseGetter<T> getter, params Cause[] dependencies)
        {
            this.getter = getter;
            foreach (Cause cause in dependencies)
            {
                addDependency(cause);
            }
        }

        public override void onUpdate()
        {
            _value = getter();
        }

    }
}
