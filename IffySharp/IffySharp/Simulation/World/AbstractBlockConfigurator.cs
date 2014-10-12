using System;


namespace IffySharp.Simulation
{
	abstract
	public class AbstractBlockConfigurator
	{
		public AbstractBlockConfigurator ()
		{
		}

		abstract
		public void configure(WorldBlock block, World world);

	}
}

