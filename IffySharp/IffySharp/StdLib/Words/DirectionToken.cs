using System;

using IffySharp.Simulation;

namespace IffySharp.StdLib.Vocab
{
	public class DirectionToken : SymbolicToken
	{
		public DirectionToken (string name) : base(name)
		{
		}

		public static void addKnowledge(SymbolicKnowledge knowledge)
		{
			knowledge.associate (WALK._.Name, WALK._);
			knowledge.associate (NORTH._.Name, NORTH._);
		}
	}


	public class NORTH : DirectionToken { public static readonly NORTH _ = new NORTH(); private NORTH() : base("north") {} }

	public class WALK : SymbolicToken { public static readonly WALK _ = new WALK();  private WALK() : base("walk") {} }

}

