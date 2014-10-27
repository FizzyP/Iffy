using System;

using IffySharp.Simulation;

namespace IffySharp.Simulation.Aspects
{
	public class KnowledgeAspect
	{
		private static readonly Object kKnowledgeKey = new Object();

		public KnowledgeAspect ()
		{
		}

		public static WorldObjectBase imbue(WorldObjectBase obj)
		{
			obj[kKnowledgeKey] = new SymbolicKnowledge();
			return obj;
		}

		public static SymbolicKnowledge getKnowledge(WorldObjectBase obj)
		{
			if (!obj.hasAttribute (kKnowledgeKey))
				return null;
			else
				return (SymbolicKnowledge) obj [kKnowledgeKey];
		}
	}
}

