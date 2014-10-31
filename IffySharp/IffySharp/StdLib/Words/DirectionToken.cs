using System;

using IffySharp.Simulation;
using IffySharp.SubParser;

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
			knowledge.associate (SOUTH._.Name, SOUTH._);
			knowledge.associate (EAST._.Name, EAST._);
			knowledge.associate (WEST._.Name, WEST._);
		}
	}


	public class WALK : SymbolicToken { public static readonly WALK _ = new WALK();  private WALK() : base("walk") {} }

	public class NORTH : DirectionToken { public static readonly NORTH _ = new NORTH(); private NORTH() : base("north") {} }
	public class SOUTH : DirectionToken { public static readonly SOUTH _ = new SOUTH(); private SOUTH() : base("south") {} }
	public class EAST : DirectionToken { public static readonly EAST _ = new EAST(); private EAST() : base("east") {} }
	public class WEST : DirectionToken { public static readonly WEST _ = new WEST(); private WEST() : base("west") {} }


}

