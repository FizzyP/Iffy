﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IffySharp.Test;

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

			var tt = new TempTerm ();
			tt.termLoop ();

			Console.WriteLine ();
			Console.WriteLine ("################################################");
			Console.WriteLine ();
			Console.WriteLine ("Iffy says goodbye!");
			Console.WriteLine ();
        }
    }
}
