using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class Vector3
    {
        public double x, y, z;
    }

    class IntVector3
    {
        public int x, y, z;

        public IntVector3(int xx, int yy, int zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }

        static public IntVector3 operator-(IntVector3 l, IntVector3 r)
        {
            return new IntVector3(l.x - r.x, l.y - r.y, l.z - r.z);
        }

        static public IntVector3 operator +(IntVector3 l, IntVector3 r)
        {
            return new IntVector3(l.x + r.x, l.y + r.y, l.z + r.z);
        }
    
    }

}
