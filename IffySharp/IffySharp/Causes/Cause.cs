using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

using IffySharp.Utilities;

namespace IffySharp
{
    abstract class Cause
    {
        //  Override this to determine the behavior of your Cause
        abstract public void onUpdate();

        //  Up and down branches in dependency tree.
        private ISet<Cause> dependencies = new SortedSet<Cause>();
        private ISet<Cause> dependents = new SortedSet<Cause>();

        //  Tagging for tree traversal algorithms
        private UInt64 traversalTag = 0;
        private static UInt64 freeTag = 1;
        private UInt64 getFreeTag() {
            return freeTag++;
        }

        //  IsDirty keeps track of whether this Cause needs to be updated.
        private bool isDirty = true;
        public bool IsDirty
        {
            set
            {
                //  This setter's purpose is to
                //  Enforce the invariant that if I am dirty so are all of my dependents and their dependents and their...

                //  Optimization
                if (value == isDirty)
                    return;

                isDirty = value;

                //  Enforce invariant
                if (isDirty)
                {
                    foreach (Cause cause in dependents)
                    {
                        cause.IsDirty = true;
                    }
                }
            }
            get
            {
                return isDirty;
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

        //public void addDependent(Cause cause)
        //{
        //    cause.addDependency(this);
        //}

        //public void removeDependent(Cause cause)
        //{
        //    cause.removeDependency(this);
        //}

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
