using System;
using IffySharp.SubParser;

namespace IffySharp.Simulation
{
	public class SimulationDispatch : Dispatch
	{
		private readonly Simulation simulation;

		public SimulationDispatch (Simulation sim)
		{
			simulation = sim;
		}

//		public void dispatch(WALK tok1, DirectionToken dir) {
//			Console.WriteLine (dispatchDescription(tok1, dir));
//		}
//
//		public bool dispatchIsValid(WALK tok1, DirectionToken dir) {
//			return true;
//		}
//
//		public string dispatchDescription(WALK tok1, DirectionToken dir) {
//			return "Walking in direction " + dir.Name;
//		}
	}



}

