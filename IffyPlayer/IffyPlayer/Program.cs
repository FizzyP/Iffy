using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Test;
using IffySharp.Parser;
using IffySharp.StdLib;

namespace IffyPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            IffyTest.test();

			Console.WriteLine ();
			Console.WriteLine ("################################################");
			Console.WriteLine ();

			var simulation = TestSimulationFactory.build ();

			var tt = new TempTerm (simulation);
			tt.termLoop ();

			Console.WriteLine ();
			Console.WriteLine ("################################################");
			Console.WriteLine ();
			Console.WriteLine ("Iffy says goodbye!");
			Console.WriteLine ();

        }
    }
}
