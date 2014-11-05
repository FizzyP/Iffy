using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Simulation.Aspects;

namespace IffySharp.Simulation
{
	[Serializable]
	public class World : WorldObjectBase
	{
		public static readonly Vector3 dim = new Vector3(100, 100, 20);
		public static readonly Vector3 center = new Vector3(50, 50, 10);

		WorldBlock[, ,] blocks = new WorldBlock[(int) dim.x, (int) dim.y, (int) dim.z];
		WorldBlock defaultBlock = null;    //  All undefined blocks map to this

		AbstractBlockConfigurator configurator;

		public World(AbstractBlockConfigurator blockConfig)
		{
			configurator = blockConfig;
			TimeAspect.imbue(this);
			EventAspect.imbue (this);
		}

		public WorldBlock peekBlock(Vector3 spot)
		{
			//	Offset so (0,0,0) is here
//			spot += center;

			if (spot.x < 0 || spot.x >= dim.x ||
				spot.y < 0 || spot.y >= dim.y ||
				spot.z < 0 || spot.z >= dim.z)
			{
				return null;
			}
			var block = blocks[(int) spot.x, (int) spot.y, (int) spot.z];
			if (block == null) {
				block = blocks[(int) spot.x, (int) spot.y, (int) spot.z] = new WorldBlock();
				//  Put the block in the spot
				MapLocationAspect.imbue(block, spot, this);
			}
			return block;
		}


		public WorldBlock getBlock(Vector3 spot)
		{
			WorldBlock block = peekBlock(spot);

			if (block == null)
				return defaultBlock;

			//  Do custom configuration
			configurator.configure(block, this);

			return block;
		}

	}
}