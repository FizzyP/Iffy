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
			Dispatch._ (COS.Tok, 3.141592);
		}
	}



}


//	Extend the dispatch method to do what you want
namespace IffySharp.SubParser
{
	public partial class Dispatch
	{
		public void dispatch(string str)
		{
			Console.WriteLine(str);
		}

		public void dispatch(COS tok, double num)
		{
			Console.WriteLine ("cos(" + num + ") = " + Math.Cos (num));
		}
	}


	public class COS {
		private static COS tok = new COS();

		static
		public COS Tok {
			get { return tok; }
		}
	}
}

