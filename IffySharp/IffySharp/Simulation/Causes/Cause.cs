using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

using IffySharp.Utilities;

namespace IffySharp.Simulation
{
    [Serializable]
    public abstract class Cause
    {
        //  Override this to determine the behavior of your Cause
        abstract public void onUpdate();

        //  Up and down branches in dependency tree.
        private HashSet<Cause> dependencies = new HashSet<Cause>();
        private HashSet<Cause> dependents = new HashSet<Cause>();

        //private SortedSet<Cause> dependencies = new SortedSet<Cause>();
        //private SortedSet<Cause> dependents = new SortedSet<Cause>();


        //  Tagging for tree traversal algorithms
        [NonSerialized]
        private UInt64 traversalTag = 0;

        private static UInt64 freeTag = 1;
        private static UInt64 getFreeTag()
        {
            return freeTag++;
        }

        //  IsDirty keeps track of whether this Cause needs to be updated.
        private bool _isDirty = true;
        public bool IsDirty
        {
            set
            {
                //  This setter's purpose is to
                //  Enforce the invariant that if I am dirty so are all of my dependents and their dependents and their...

                //  Optimization
                if (value == _isDirty)
                    return;

                _isDirty = value;

                //  Enforce invariant
                if (_isDirty)
                {
					//	Mark them all dirty instantaneously so that if calling _is
					foreach (Cause cause in dependents)
						_isDirty = true;
                    foreach (Cause cause in dependents)
                        cause.IsDirty = true;
                }

				if (value && !IsLazy) {
					update ();
				}

            }
            get
            {
                return _isDirty;
            }
        }

        //  If !isLazy then marking an object dirty causes it to immediately update
        private bool _isLazy = true;
        public bool IsLazy
        {
            set
            {
                _isLazy = value;
                //  If we're not lazy but dirty, immediately fix this problem
                if (!_isLazy && _isDirty)
                    update();
            }
            get
            {
                return _isLazy;
            }
        }

        public void update()
        {
            if (!IsDirty)
                return;

            //  Make sure all of our dependencies are up to date
            foreach (Cause cause in dependencies)
            {
                cause.update();
            }

            //  Do whatever we're overriden to do
            onUpdate();
            IsDirty = false;

            //  Update every cause that depends on us:
            //  First mark them all dirty
            foreach (Cause cause in dependents)
            {
                cause.IsDirty = true;
            }
            //  Update them all
            foreach (Cause cause in dependents)
            {
                cause.update();
            }
        }

        public void addDependency(Cause cause)
        {
            //  Check for circular dependencies
            if (cause.isDependentOn(this))
                throw new CircularDependencyException("", this, cause);

            dependencies.Add(cause);
            cause.dependents.Add(this);
            if (cause.IsDirty)
                IsDirty = true;
        }

        public void removeDependency(Cause cause)
        {
            dependencies.Remove(cause);
            cause.dependents.Remove(this);
        }

        private bool isDependentOn(Cause otherCause)
        {
            UInt64 tag = getFreeTag();
            otherCause.tagDependents(tag);
            //  If we ended up tagging ourself then we're dependent on otherCause
            return this.traversalTag == tag;
        }

        private void tagDependents(UInt64 tag)
        {
            foreach (Cause cause in dependents)
            {
                //  Skip it if we've already marked it
                if (cause.traversalTag == tag)
                    continue;

                cause.traversalTag = tag;
                cause.tagDependents(tag);
            }
        }
    }
}
