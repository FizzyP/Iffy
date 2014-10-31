using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
		public readonly TerminalDispatch terminalDispatch;
		public readonly Player player;
		public readonly Camera camera;
		public readonly SimulationDispatch simulationDispatch; 

		public readonly IffySharp.Parser.Parser parser;
		private IIffyRenderer renderer;

		public Simulation (WorldState state, IIffyRenderer renderer, World startWorld, WorldBlock startBlock, TerminalDispatch dispatch)
		{
			if (state == null) {
				throw new ImplementationError ();
			}
				
			this.state = state;

			this.renderer = renderer;

			player = new Player (startBlock);

			this.simulationDispatch = new SimulationDispatch (this);	//	not safe but doesn't matter.  Won't use dispatch until initialized.
			this.terminalDispatch = dispatch;
			this.parser = new IffySharp.Parser.Parser (terminalDispatch, KnowledgeAspect.getKnowledge (player));

			this.camera = Camera.new_FollowingObject (player, renderer);
		}


		public void save(string fileName)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, state);
			stream.Close();
		}

		public void load(string fileName)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			WorldState obj = (WorldState) formatter.Deserialize(stream);
			stream.Close();
		}

		public void advanceTime(double dtSeconds)
		{
			var world = MapLocationAspect.getMapLocationState (player).world;
			var timeCause = TimeAspect.getTimeCause (world);

			timeCause.advanceTime (dtSeconds);
		}

		public void enqueueCause(Cause cause, DateTime atTime)
		{
			var world = MapLocationAspect.getMapLocationState (player).world;
			var timeCause = TimeAspect.getTimeCause (world);

			timeCause.enqueueCause (atTime, cause);
		}
	}
}

