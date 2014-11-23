
namespace IffySharp.Simulation.Aspects
{
	abstract
	public class DescriptionAspect
	{
		//	Tokens for different types of descriptions
		public static readonly object Short = new object();

		public static WorldObjectBase imbue(WorldObjectBase obj, Description description)
		{
			obj[Short] = description;
			return obj;
		}

		public static Description getDescription(object key, WorldObjectBase obj)
		{
			if (!obj.hasAttribute (key))
				return null;
			else
				return (Description) obj [key];
		}
	}
}

