using System;
using IffySharp.SubParser;

namespace IffySharp.SubParser.Test
{
	static
	public class SubParserTest
	{
		public static void test()
		{
			Dispatch._("naked time");
		}
	}



}

namespace IffySharp.SubParser
{
	public partial class Dispatch
	{
		public void dispatch(string str)
		{
			Console.WriteLine(str);
		}
	}
}

