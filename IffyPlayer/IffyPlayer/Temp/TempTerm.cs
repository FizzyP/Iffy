using System;

namespace IffyPlayer
{
	public class TempTerm
	{

		public TempTerm ()
		{
		}

		public void termLoop()
		{
			bool shouldContinue = true;

			while (shouldContinue)
			{
				Console.Write ("> ");
				string input = Console.ReadLine ();
				string[] words = input.Split( new[] {' ', '\t'}, 100);
				shouldContinue = parseInput(words);
			}

		}


		bool parseInput(string[] words)
		{
			if (words == null || words.Length == 0)
				return true;

			switch (words [0]) {

			case "q":
			case "quit":
				return false;

			default:
				report ("I don't know the word " + words [0] + ".");
				break;
			}
			return true;
		}



		void report(string text)
		{
			Console.WriteLine (text);
		}

	}
}

