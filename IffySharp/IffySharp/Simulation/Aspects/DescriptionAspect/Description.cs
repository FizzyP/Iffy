
using System;


namespace IffySharp.Simulation.Aspects
{
	public delegate SensationInterpretation SensationInterpretationChooser(SensationInterpretation[] interpretations);

	public delegate string DescriptionGetter(WorldObjectBase to, WorldObjectBase of, SensationInterpretationChooser chooser);

	public class Description
	{
		private DescriptionGetter getter;

		public Description(DescriptionGetter getter)
		{
			this.getter = getter;
		}


		public string get(WorldObjectBase to, WorldObjectBase of, SensationInterpretationChooser chooser)
		{
			return getter (to, of, chooser);
		}

		public static implicit operator Description(string text)
		{
			return new Description(new DescriptionGetter(
				(to, of, chooser)	=> 	text
			));
		}

		public static Description operator+(Description left, Description right)
		{
			return new Description(new DescriptionGetter(
				(to, of, chooser)	=>	left.get(to, of, chooser) + right.get(to, of, chooser)
			));
		}
	}
}

