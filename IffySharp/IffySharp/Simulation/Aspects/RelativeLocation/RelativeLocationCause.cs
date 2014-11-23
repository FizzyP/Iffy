using System;
using System.Collections.Generic;

using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class RelativeLocationCause : Cause
	{
		private readonly RelativeLocationState relations = new RelativeLocationState();

		public IReadOnlyDictionary<WorldObjectBase, RelativeLocationLinkCause> Relations {
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

		public void clearAll()
		{
			var dictCopy = new Dictionary<WorldObjectBase, RelativeLocationLinkCause> (relations);
			foreach (var kv in dictCopy) {
				this [kv.Key] = null;
			}
		}

		public RelativeLocationLinkCause this[WorldObjectBase obj]
		{
			get {
				update ();
				return relations[obj];
			}
			set {
				if (value == null) {
					if (relations.ContainsKey (obj)) {
						var link = relations [obj];

						this.removeDependency (link);
						relations.Remove (obj);

						link.Value = RelativeLocationLink.NoLink;
					}
				} else {
					if (relations.ContainsKey (obj)) {
						var link = relations [obj];

						this.removeDependency (link);
						relations.Remove (obj);

						link.Value = RelativeLocationLink.NoLink;
					}
					relations [obj] = value;
					addDependency (value);
				}
				IsDirty = true;
			}
		}
	}
}

