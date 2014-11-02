﻿using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Actions;


namespace IffySharp.StdLib
{
	static
	public class TestCommand
	{
		public static void addKnowledge(SymbolicKnowledge knowledge)
		{
			knowledge.associate (TEST._.Name, TEST._);
			knowledge.associate ("t", TEST._);
		}
	}


	public partial class StdTerminalDispatch
	{
		//	Walk in a direction
		public void dispatch(TEST tok1) {
			//	Do something here!

		}

		public bool dispatchIsValid(TEST tok1) {
			return true;
		}

		public string dispatchDescription(TEST tok1) {
			return "Test Command";
		}
	}


}

