using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Utilities
{
    class CircularDependencyException : Exception
    {
        readonly Cause Cause1, Cause2;

        public CircularDependencyException(string message, Cause a, Cause b)
            : base(message)
        {
            Cause1 = a;
            Cause2 = b;
        }
    }
}
