
using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;
using IffySharp.SubParser;

namespace IffySharp.Simulation.Actions //.Movement
{
	static
	public class Movement
	{
		//	subj moves obj to indirObj
		static
		public void move(WorldObjectBase subj, WorldObjectBase obj, WorldObjectBase indirObj, Simulation sim)
		{

		}
	}

	public partial class SimulationDispatch
	{
		//	"god" moves obj to indirObjBlock in sim
		public void dispatch(TELEPORT tok1, GOD tok2, WorldObjectBase obj, WorldBlock indirObjBlock, Simulation sim)
		{
			var locCause = MapLocationAspect.getCause (obj);
			if (locCause == null) {
				throw new InvalidDispatchException ("Cannot invoke teleport on object with no map location.");
			}

			//var locState = locCause.Value;
			var blockLocState = MapLocationAspect.getCause (indirObjBlock).Value;

			//	Do the movement
			locCause.Value = blockLocState;
		}

		public bool dispatchIsValid(TELEPORT tok1, GOD tok2, WorldObjectBase obj, WorldBlock indirObjBlock, Simulation sim) {
			return true;
		}

		public string dispatchDescription(TELEPORT tok1, GOD tok2, WorldObjectBase obj, WorldBlock indirObjBlock, Simulation sim) {
			return "God teleports " + obj.ToString()  + " to " + indirObjBlock.ToString() + ".";
		}
	}
}


