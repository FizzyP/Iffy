using System;
using System.Collections.Generic;
using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class GravityCause : Cause
	{
		WorldObjectBase target;
		RelativeLocationLinkCause supportingLink;



		public GravityCause (WorldObjectBase target)
		{
			this.target = target;

			var locCause = MapLocationAspect.getCause (target);
			if (locCause == null)
				throw new ArgumentException ("Target must possess map location aspect.");
			addDependency (locCause);

			var relLocCause = RelativeLocationAspect.getCause (target);
			if (relLocCause == null)
				throw new ArgumentException ("Target must possess relative location aspect.");
			addDependency (relLocCause);

			IsLazy = false;

			AllCauses.Add (this);
		}


		override
		public void onUpdate()
		{
			RelativeLocationLinkCause link;

			if (null == targetIsSupported (out link)) {
				fall ();
			} else {
				landOn (link);
			}
		}

		void landOn(RelativeLocationLinkCause link)
		{
			if (this.supportingLink != null)
				this.removeDependency (supportingLink);
			supportingLink = link;
			this.addDependency (supportingLink);
		}


		//	Determine if the target is supported.  Return the object if it's found and
		//	the link if it already exists
		private WorldObjectBase targetIsSupported(out RelativeLocationLinkCause link)
		{
			var relLocCause = RelativeLocationAspect.getCause (target);

			//	Is it on something?
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
				//	Make an "on" relationship between our feet and the ground
				link = new RelativeLocationLinkCause ();
				link.Value = new RelativeLocationLink (OnPreposition._, SurfaceContactLinkType._);
				relLocCause [maybeGroundBlock] = link;
				return maybeGroundBlock;
			}
				
			link = null;
			return null;
		}

		DateTime nextQueuedFallingTime;

		private void fall()
		{
			var mapLocCause = MapLocationAspect.getCause (target);
			var world = mapLocCause.Value.world;
			var time = TimeAspect.getTimeCause (world);

			//	Our old link is useless
			if (supportingLink != null)
				this.removeDependency (supportingLink);

			var originWorldEvents = EventAspect.getCause (world);

			var pos = mapLocCause.Value.position;
			var nextPos = new Vector3(pos.x, pos.y, pos.z - 1);
			var velocity = new Vector3 (0, 0, -1);

			var newMapLoc = new MapLocationState (mapLocCause.Value.world,
				nextPos, velocity);

			//	Actually move the player.  Do it in a away that suppresses this cause
			//	being marked dirty again.
			//	mapLocCause.Value = newMapLoc;
			mapLocCause.setValueAsDependent (newMapLoc, this);

			//	The observable event happens
			originWorldEvents.Value = new FallingEvent ();

			//	Queue more falling to happen
			nextQueuedFallingTime = time.Time.AddSeconds (1);
			time.enqueueCause (nextQueuedFallingTime, this);
		}




		public static readonly HashSet<GravityCause> AllCauses = new HashSet<GravityCause>();

		public static void markAllInstancesDirty()
		{
			foreach (GravityCause gc in AllCauses) {
				gc.IsDirty = false;
				gc.IsDirty = true;
			}
		}

	}
}

