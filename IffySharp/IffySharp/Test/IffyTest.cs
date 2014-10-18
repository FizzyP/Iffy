using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Simulation.Test;
using IffySharp.SubParser.Test;


namespace IffySharp.Test
{
    public class IffyTest
    {
        public static void test()
        {
			CauseTest.test ();
			WorldTest.test();
			SubParserTest.test ();
        }
    }
}
