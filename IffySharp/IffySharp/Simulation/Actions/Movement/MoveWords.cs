
using IffySharp.SubParser;

namespace IffySharp.Simulation.Actions
{
	public class MOVE : SymbolicToken { public static readonly MOVE _ = new MOVE();  private MOVE() : base("move") {} }
	public class TELEPORT : SymbolicToken { public static readonly TELEPORT _ = new TELEPORT();  private TELEPORT() : base("teleport") {} }
}
