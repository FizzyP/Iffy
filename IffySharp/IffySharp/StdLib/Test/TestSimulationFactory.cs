using System;

using IffySharp;
using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;
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
			var startSpot = new Vector3 (0, 0, 0);
			var startBlock = world.getBlock (startSpot);

			var renderer = new SimpleRenderer ();

			var sim = new IffySharp.Simulation.Simulation (worldState, renderer, world, startBlock, new StdTerminalDispatch());
//			Simulation.Instance = sim;

			Global.Simulation = sim;

			//	Add vocab to player
			var player = sim.player;
			var playerKnowledge = KnowledgeAspect.getKnowledge (player);

			WalkTerminalCommand.addKnowledge (playerKnowledge);
			LookTerminalCommand.addKnowledge (playerKnowledge);

			//	Temporary stuff
			TestCommand.addKnowledge (playerKnowledge);
			playerKnowledge.associate ("self", player);

			return sim;
		}
			
	}

}

