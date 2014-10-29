using System;
using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class MapLocationState
	{
		public World world;
		public IntVector3 position;
		public Vector3 velocity;
	}

	class MapLocationCause : ValueCause<MapLocationState>
	{
		public MapLocationCause(MapLocationState initialLocation)
			: base(initialLocation)
		{ }
	}
}

