using System;
using IffySharp.Parser;
using EeekSoft.Text;

namespace IffyPlayer
{
	public class TempTerm
	{

		private Parser parser;

		public TempTerm (Parser parser)
		{
			this.parser = parser;
		}

		public void termLoop()
		{
			bool shouldContinue = true;

			while (shouldContinue)
			{
				Console.WriteLine ();
				Console.Write ("> ");
				shouldContinue = parseInput(Console.ReadLine ());
			}
		}


		bool parseInput(string input)
		{
			string[] words = input.Split( new[] {' ', '\t'}, 100);

			if (words == null || words.Length == 0)
				return true;

			switch (words [0]) {

			case "q":
			case "quit":
				return false;
			}

			parser.parse (input);
			return true;
		}
			
		void report(string text)
		{
			Console.WriteLine (text);
		}


		private void traverse(object[] symbols)
		{
		}
	}
}

