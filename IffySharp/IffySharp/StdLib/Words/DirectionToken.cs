using System;

using IffySharp.Simulation;

namespace IffySharp.StdLib.Vocab
{
	public class DirectionToken : SymbolicToken
	{
		public DirectionToken ()
		{
		}

		public static void addKnowledge(SymbolicKnowledge knowledge)
		{
			knowledge.associate ("walk", WALK._);
			knowledge.associate ("north", NORTH._);
		}
	}


	public class NORTH : DirectionToken { public static readonly NORTH _ = new NORTH(); }

	public class WALK : SymbolicToken { public static readonly WALK _ = new WALK(); }

}

