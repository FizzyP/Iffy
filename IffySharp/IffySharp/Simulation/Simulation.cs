using System;
using IffySharp;
using IffySharp.Parser;
using IffySharp.SubParser;
using IffySharp.Simulation;
using IffySharp.StdLib;
using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	public class Simulation
	{
		private WorldState state;
		private IIffyRenderer renderer;
		public readonly Dispatch terminalDispatch;
		public readonly IffySharp.Parser.Parser parser;
		public readonly Player player;
		public readonly Camera camera;

		public Simulation (WorldState state, IIffyRenderer renderer, World startWorld, WorldBlock startBlock)
		{
			if (state == null) {
				throw new ImplementationError ();
			}
				
			this.state = state;

			this.renderer = renderer;

			player = new Player (startBlock);

			this.terminalDispatch = new Dispatch();
			this.parser = new IffySharp.Parser.Parser (terminalDispatch, KnowledgeAspect.getKnowledge (player));

			this.camera = Camera.new_FollowingObject (player, renderer);
		}
	}
}

