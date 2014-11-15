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

						relations.Remove (obj);

						link.Value = new RelativeLocationLink () {
							linkType = NoConnectionLinkType._,
							preposition = NoPreposition._
						};
						link.IsDirty = true;								//	Update it
					}
				} else {
					if (relations.ContainsKey (obj)) {
						var link = relations [obj];

						relations.Remove (obj);

						link.Value = new RelativeLocationLink () {
							linkType = NoConnectionLinkType._,
							preposition = NoPreposition._
						};
						link.IsDirty = true;								//	Update it
					}
					relations [obj] = value;
				}
				IsDirty = true;
			}
		}
	}
}

