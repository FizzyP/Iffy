using System;
using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class GravityCause : Cause
	{
		WorldObjectBase target;
		RelativeLocationLinkCause supportingLink;

//		MapLocationCause locCause;
//		RelativeLocationCause relLocCause;

		public GravityCause (WorldObjectBase target)
		{
			this.target = target;

			var locCause = MapLocationAspect.getCause (target);
			if (locCause == null)
				throw new ArgumentException ("Target must possess map location aspect.");
//			addDependency (locCause);
//
//			relLocCause = RelativeLocationAspect.getCause (target);
//			if (relLocCause == null)
//				throw new ArgumentException ("Target must possess relative location aspect.");
//			addDependency (relLocCause);

			IsLazy = false;
		}

		override
		public void onUpdate()
		{
			RelativeLocationLinkCause link;

			if (null == targetIsSupported (out link)) {
				fall ();
			} else {
				if (this.supportingLink != null)
					this.removeDependency (supportingLink);
				supportingLink = link;
				this.addDependency (supportingLink);
			}
		}



		//	Determine if the target is supported.  Return the object if it's found and
		//	the link if it already exists
		private WorldObjectBase targetIsSupported(out RelativeLocationLinkCause link)
		{
			//	Is it on something?
			var relLocCause = RelativeLocationAspect.getCause (target);
			if (relLocCause != null) {
				foreach (var kv in relLocCause.Relations) {
					if (kv.Value.Value.preposition == OnPreposition._) {
						link = kv.Value;
						return kv.Key;
					}
				}
			}

			//	What's under our feet?
			var mapLocCause = MapLocationAspect.getCause (target);
			var pos = mapLocCause.Value.position;
			var feetPos = new Vector3(pos.x, pos.y, pos.z - 1);
			var maybeGroundBlock = mapLocCause.Value.world.getBlock (feetPos);

			if (maybeGroundBlock.IsSolid.Value) {
				link = null;
				return maybeGroundBlock;
			}
				
			link = null;
			return null;
		}

		private void fall()
		{
			//	Our old link is useless
			if (supportingLink != null)
				this.removeDependency (supportingLink);

			var mapLocCause = MapLocationAspect.getCause (target);
			var world = mapLocCause.Value.world;
			var originWorldEvents = EventAspect.getCause (world);

			var pos = mapLocCause.Value.position;
			var nextPos = new Vector3(pos.x, pos.y, pos.z - 1);
			var velocity = new Vector3 (0, 0, -1);

			var newMapLoc = new MapLocationState (mapLocCause.Value.world,
				nextPos, velocity);

			//	Actually move the player
			mapLocCause.Value = newMapLoc;
			//	The observable event happens
			originWorldEvents.Value = new FallingEvent ();

			//	Queue more falling to happen
			var time = TimeAspect.getTimeCause (world);
			var nextFallingTime = time.Time.AddSeconds (1);
			time.enqueueCause (nextFallingTime, this);
		}

	}
}

