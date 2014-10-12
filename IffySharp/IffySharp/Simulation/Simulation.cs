using System;
using IffySharp;

namespace IffySharp.Simulation
{
	public class Simulation
	{
		private WorldState state;
		private IIffyRenderer renderer;


		public Simulation (WorldState state, IIffyRenderer renderer)
		{
			if (state == null) {
				throw new ImplementationError ();
			}
				
			this.state = state;
			this.renderer = renderer;
		}
	}
}

