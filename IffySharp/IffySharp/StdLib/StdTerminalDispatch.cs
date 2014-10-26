using System;

using IffySharp.SubParser;
using IffySharp.StdLib.Vocab;

namespace IffySharp.StdLib
{
	public class StdTerminalDispatch : TerminalDispatch
	{
		public StdTerminalDispatch ()
		{
		}


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

