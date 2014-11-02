using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    public class Vector3
    {
        public readonly double x, y, z;

        public Vector3(double xx, double yy, double zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }

		static public Vector3 operator-(Vector3 l, Vector3 r)
		{
			return new Vector3(l.x - r.x, l.y - r.y, l.z - r.z);
		}

		static public Vector3 operator +(Vector3 l, Vector3 r)
		{
			return new Vector3(l.x + r.x, l.y + r.y, l.z + r.z);
		}

	}

    public class IntVector3
    {
        public readonly int x, y, z;

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
