using System;
using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class MapLocationState
	{
		public MapLocationState(World world, Vector3 position, Vector3 velocity)
		{
			this.world = world;
			this.position = position;
			this.velocity = velocity;
		}

		public readonly World world;
		public readonly Vector3 position;
		public readonly Vector3 velocity;
	}

	class MapLocationCause : ValueCause<MapLocationState>
	{
		public MapLocationCause(MapLocationState initialLocation)
			: base(initialLocation)
		{ }
	}
}

