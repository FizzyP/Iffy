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
        ISet<Cause> dependencies = new SortedSet<Cause>();
        ISet<Cause> dependents = new SortedSet<Cause>();

        //  Tagging for tree traversal algorithms
        public UInt64 traversalTag = 0;
        private static UInt64 freeTag = 1;
        public UInt64 getFreeTag() {
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

        //  Override this to determine the behavior of your Cause
        abstract public void onUpdate();
        
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
            if (cause.IsDirty)
                IsDirty = true;
        }

        public void removeDependency(Cause cause)
        {
            dependencies.Remove(cause);
        }

        public void addDependent(Cause cause)
        {
            //  Check for circular dependencies
            if (this.isDependentOn(cause))
                throw new CircularDependencyException("", cause, this);

            dependents.Add(cause);
            if (IsDirty)
                cause.IsDirty = true;
        }

        public void removeDependent(Cause cause)
        {
            dependents.Remove(cause);
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
