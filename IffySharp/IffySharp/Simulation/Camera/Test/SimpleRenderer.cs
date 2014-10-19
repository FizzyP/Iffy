using System;

using IffySharp;

namespace IffySharp.Simulation.Test
{
	public class SimpleRenderer : IIffyRenderer
	{
		public SimpleRenderer ()
		{
		}


		public void render(string text)
		{
			Console.WriteLine (text);
		}

	}
}

