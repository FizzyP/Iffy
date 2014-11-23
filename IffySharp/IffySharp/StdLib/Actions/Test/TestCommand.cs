using System;

using IffySharp.Simulation;
using IffySharp.Simulation.Actions;
using IffySharp.Simulation.Aspects;
using IffySharp.SubParser;


namespace IffySharp.StdLib
{
	static
	public class TestCommand
	{
		public static void addKnowledge(SymbolicKnowledge knowledge)
		{
			knowledge.associate (TEST._.Name, TEST._);
			knowledge.associate ("t", TEST._);
		}

		public static void test1(Dispatch exec, Player player)
		{
			var playerLoc = MapLocationAspect.getMapLocationState (player);
			//			var playerLocBlock = playerLoc.world.getBlock (playerLoc.position);
			var playerLocBlock = playerLoc.world.getBlock (World.center + new Vector3(0, 0, 1));


			// TRY CATCH REMOVED TO IMPROVE ERROR DETECTION
			//			try {
			Dispatch._ (exec, TELEPORT._, GOD._, player, playerLocBlock);
			//			}
			//			catch (Exception ex) {
			//				Console.Write ("whoops");
			//			}

		}
	}


	public partial class StdTerminalDispatch : TerminalDispatch
	{
		//	Walk in a direction
		public void dispatch(TEST tok1) {
			//	Do something here!
//			var x = new 
			var exec = Global.Simulation.simulationDispatch;
			var player = Global.Simulation.player;

			TestCommand.test1 (exec, player);
		}

		public bool dispatchIsValid(TEST tok1) {
			return true;
		}

		public string dispatchDescription(TEST tok1) {
			return "Test Command";
		}
	}

}


