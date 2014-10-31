using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IffySharp.Simulation
{
    class IFKV : Dictionary<Object, Object> { }

    public class WorldObjectBase
    {
        private readonly IFKV attributes = new IFKV();

		public WorldObjectBase()
		{
			InternalDescription = "(no description)";
		}

        public Object this[Object key] {
            get
            {
                object value;
                attributes.TryGetValue(key, out value);
                return value;
            }
            set
            {
                attributes[key] = value;
            }
        }

        public T get<T>(Object key)
        {
            return (T) this[key];
        }

		public bool hasAttribute(Object key)
		{
			return attributes.ContainsKey (key);
		}

		virtual
		public string InternalDescription {
			set;
			get;
		}

    }
}
