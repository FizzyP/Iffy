using System;
using IffySharp.Parser;
using EeekSoft.Text;

namespace IffyPlayer
{
	public class TempTerm
	{
		public delegate void SymbolicationTask(object[] symbols);

		public TempTerm (Parser parser)
		{
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





			return true;
		}


		private void symbolicate(string text, SymbolicationTask task)
		{

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

