
using IffySharp.SubParser;

namespace IffySharp.StdLib
{
	public class DirectionToken : SymbolicToken
	{
		public DirectionToken (string name) : base(name)
		{
		}

	}


	public class WALK : SymbolicToken { public static readonly WALK _ = new WALK();  private WALK() : base("walk") {} }

	public class NORTH : DirectionToken { public static readonly NORTH _ = new NORTH(); private NORTH() : base("north") {} }
	public class SOUTH : DirectionToken { public static readonly SOUTH _ = new SOUTH(); private SOUTH() : base("south") {} }
	public class EAST : DirectionToken { public static readonly EAST _ = new EAST(); private EAST() : base("east") {} }
	public class WEST : DirectionToken { public static readonly WEST _ = new WEST(); private WEST() : base("west") {} }

}
