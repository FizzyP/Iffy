using System;

using IffySharp.SubParser;
using IffySharp.Simulation;

namespace IffySharp.StdLib
{
	static
	public class LookTerminalCommand
	{
		public static void addKnowledge(SymbolicKnowledge knowledge)
		{
			knowledge.associate (LOOK._.Name, LOOK._);
			knowledge.associate ("examine", LOOK._);
			knowledge.associate ("x", LOOK._);

		}
	}

	public partial class StdTerminalDispatch
	{
		//	Look at something
		public void dispatch(LOOK tok1, WorldObjectBase obj) {
			Console.WriteLine (dispatchDescription(tok1, obj));
		}

		public bool dispatchIsValid(LOOK tok1, WorldObjectBase dir) {
			return true;
		}

		public string dispatchDescription(LOOK tok1, WorldObjectBase dir) {
			return "Looking at something.";
		}
	}

}

