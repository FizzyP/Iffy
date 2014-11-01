﻿using System;
using System.Text;
using System.Threading;
using EeekSoft.Text;

using IffySharp.Parser;
using IffySharp.Simulation;


namespace IffyPlayer
{
	public class TempTerm
	{

		private Parser parser;
		private Simulation simulation;

		public TempTerm (Simulation simulation)
		{
			this.parser = simulation.parser;
			this.simulation = simulation;
		}

		public void termLoop()
		{
			bool shouldContinue = true;
			var lastUpdateTime = DateTime.Now;
			var inputBuilder = new StringBuilder ();



			while (shouldContinue)
			{
				Console.WriteLine ();
				Console.Write ("> ");

				inputBuilder.Clear ();

				while (true) {
					if (Console.KeyAvailable) {
						var keyInfo = Console.ReadKey (true);
						var c = keyInfo.KeyChar;

					
						if (keyInfo.Key == ConsoleKey.Enter) {
							Console.WriteLine ();
							string text = inputBuilder.ToString ().ToLowerInvariant ();

							shouldContinue = parseInput (text);
							break;
						} else if (keyInfo.Key == ConsoleKey.Backspace) {
						}

						writeKeyToConsole(keyInfo);
						writeKeyToInput(keyInfo, inputBuilder);
					
					} else {
						//	Update every milisecond
						var now = DateTime.Now;
						var dt = now.Subtract(lastUpdateTime).TotalSeconds;
						lastUpdateTime = now;

						simulation.advanceTime (dt);

						Thread.Sleep (2);
					}
				}

			}
		}

		private void writeKeyToInput(ConsoleKeyInfo key, StringBuilder input)
		{
			if (key.Key == ConsoleKey.Backspace) {
				if (input.Length > 0) {
					input.Remove (input.Length - 1, 1);
				}
			} else {
				input.Append (key.KeyChar);
			}
		}

        private void writeKeyToConsole(ConsoleKeyInfo key)
        {
			if (key.Key == ConsoleKey.Backspace)
            {
                Console.Write("\b \b");  //	In visual studio console the backspace doesn't overwrite for some reason.
            }
            else
            {
				Console.Write (key.KeyChar);
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

	}
}

