using System;
using IffySharp.Simulation;
using IffySharp;
using IffySharp.Simulation.Test;

namespace IffySharp.StdLib
{
	abstract
	public class TestSimulationFactory
	{
		//		public Simulation (WorldState state, IIffyRenderer renderer, World startWorld, WorldBlock startBlock)



		static
		public IffySharp.Simulation.Simulation build()
		{
			var worldState = new WorldState ();
			var configurator = new TestBlockConfigurator ();
			var world = new World (configurator);
			worldState.worlds.Add (world);
			var startBlock = world.getBlock (new IntVector3 (0, 0, 0));

			var renderer = new SimpleRenderer ();

			var sim = new IffySharp.Simulation.Simulation (worldState, renderer, world, startBlock);

			return sim;
		}
			
	}

}

