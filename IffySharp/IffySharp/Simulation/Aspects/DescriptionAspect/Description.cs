
using System;


namespace IffySharp.Simulation.Aspects
{
	public delegate string DescriptionGetter(WorldObjectBase to, WorldObjectBase of);

	public class Description
	{
		private DescriptionGetter getter;

		public Description(DescriptionGetter getter)
		{
			this.getter = getter;
		}


		public string get(WorldObjectBase to, WorldObjectBase of)
		{
			return getter (to, of);
		}

		public static implicit operator Description(string text)
		{
			return new Description(new DescriptionGetter(
				(to, of)	=> 	text
			));
		}

		public static Description operator+(Description left, Description right)
		{
			return new Description(new DescriptionGetter(
				(to, of)	=>	left.get(to, of) + right.get(to, of)
			));
		}
	}
}

