using System;
using System.Collections.Generic;

using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class RelativeLocationCause : Cause
	{
		private readonly RelativeLocationState relations = new RelativeLocationState();

		public IReadOnlyDictionary<WorldObjectBase, Preposition> Relations {
			get {
				return relations;
			}
		}


		public RelativeLocationCause ()
		{
		}

		override
		public void onUpdate()
		{
		}

		public Preposition this[WorldObjectBase obj]
		{
			get {
				update ();
				return relations[obj];
			}
			set {
				if (value == null)
					relations.Remove (obj);
				else
					relations [obj] = value;
				IsDirty = true;
			}
		}
	}
}

