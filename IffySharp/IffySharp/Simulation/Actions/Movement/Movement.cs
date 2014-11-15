
using IffySharp.Simulation;
using IffySharp.Simulation.Aspects;
using IffySharp.SubParser;
using IffySharp.Simulation.Actions;

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



}

namespace IffySharp.Simulation
{
	//	"god" moves obj to indirObjBlock in sim
	public partial class SimulationDispatch : Dispatch
	{
		public void dispatch(TELEPORT tok1, GOD tok2, WorldObjectBase obj, WorldBlock indirObjBlock)
		{
			var objectLocation = MapLocationAspect.getCause (obj);
			if (objectLocation == null) {
				throw new InvalidDispatchException ("Cannot invoke teleport on object with no map location.");
			}

			//var locState = locCause.Value;
			var blockLocState = MapLocationAspect.getCause (indirObjBlock).Value;

			var originWorldEvents = EventAspect.getCause (objectLocation.Value.world);

			//	Post the dematerialization event
			originWorldEvents.Value = new DematerializationEvent (obj);

			//	Actually change the position state of the object
			objectLocation.Value = blockLocState;

			//	
			var objectRelLoc = RelativeLocationAspect.getCause (obj);
		}

		public bool dispatchIsValid(TELEPORT tok1, GOD tok2, WorldObjectBase obj, WorldBlock indirObjBlock) {
			return true;
		}

		public string dispatchDescription(TELEPORT tok1, GOD tok2, WorldObjectBase obj, WorldBlock indirObjBlock) {
			return "God teleports " + obj.ToString()  + " to " + indirObjBlock.ToString() + ".";
		}
	}
}


