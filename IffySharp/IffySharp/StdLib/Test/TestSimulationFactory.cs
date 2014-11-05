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

			buildBaseSimulation ();

			var sim = Global.Simulation;
			var player = sim.player;
			var playerKnowledge = KnowledgeAspect.getKnowledge (player);

			WalkTerminalCommand.addKnowledge (playerKnowledge);
			LookTerminalCommand.addKnowledge (playerKnowledge);

			//	Temporary stuff
			TestCommand.addKnowledge (playerKnowledge);
			playerKnowledge.associate ("self", player);

			return sim;
		}


		static private void buildBaseSimulation()
		{
			var worldState = new WorldState ();
			var configurator = new TestBlockConfigurator ();
			var world = new World (configurator);
			worldState.worlds.Add (world);
			var startBlock = world.getBlock (World.center);

			var renderer = new SimpleRenderer ();

			var sim = new IffySharp.Simulation.Simulation (worldState, renderer, world, startBlock, new StdTerminalDispatch());

			Global.Simulation = sim;
		}
			
	}

}

