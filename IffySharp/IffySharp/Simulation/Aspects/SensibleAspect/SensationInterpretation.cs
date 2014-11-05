using System;

using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class SensationInterpretation : WorldObjectBase
	{
		public static readonly Object kCompositeStringSensationKey = new Object();


		private SensationInterpretation ()
		{
		}



		static
		public SensationInterpretation new_composite(Description description)
		{
			var x = new SensationInterpretation ();
			x [kCompositeStringSensationKey] = description;
			return x;
		}
	}
}

