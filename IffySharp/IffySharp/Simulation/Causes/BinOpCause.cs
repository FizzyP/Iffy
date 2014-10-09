using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    public delegate T BinOpGetter<T>(T x, T y);

    class BinOpCause<T> : FunctionCause<T>
    {
        ValueCause<T> left, right;
        BinOpGetter<T> binOpGetter;

        public BinOpCause(BinOpGetter<T> binOp, ValueCause<T> left, ValueCause<T> right)
            : base(() => binOp(left.Value, right.Value), left, right)
        {
            binOpGetter = binOp;
            this.left = left;
            this.right = right;
        }
    }
}
