using System;
using IffySharp.SubParser;

namespace IffySharp.Simulation
{
	public partial class SimulationDispatch : Dispatch
	{
		private readonly Simulation simulation;

		public SimulationDispatch (Simulation sim)
		{
			simulation = sim;
		}

	}

}

