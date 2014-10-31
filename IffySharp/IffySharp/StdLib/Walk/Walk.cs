
using System;
using IffySharp.StdLib.Vocab;
using IffySharp.Simulation;


namespace IffySharp.StdLib
{
	static
	public class WalkTerminalCommand
	{
		public static void addKnowledge(SymbolicKnowledge knowledge)
		{
			knowledge.associate (WALK._.Name, WALK._);
			knowledge.associate ("w", WALK._);
			knowledge.associate ("go", WALK._);

			knowledge.associate (NORTH._.Name, NORTH._);
			knowledge.associate ("n", NORTH._);
			knowledge.associate (SOUTH._.Name, SOUTH._);
			knowledge.associate ("s", SOUTH._);
			knowledge.associate (EAST._.Name, EAST._);
			knowledge.associate ("e", EAST._);
			knowledge.associate (WEST._.Name, WEST._);
			knowledge.associate ("w", WEST._);
		}
	}


	public partial class StdTerminalDispatch
	{
		//	Walk in a direction
		public void dispatch(WALK tok1, DirectionToken dir) {
			Console.WriteLine (dispatchDescription(tok1, dir));
		}

		public bool dispatchIsValid(WALK tok1, DirectionToken dir) {
			return true;
		}

		public string dispatchDescription(WALK tok1, DirectionToken dir) {
			return "Walking in direction " + dir.Name;
		}
	}


}


