using System;

using IffySharp.StdLib.Vocab;

namespace IffySharp.SubParser
{

	public partial class Dispatch
	{
		public static readonly Dispatch Instance = new Dispatch();



		public Dispatch() {}


		public void dispatch(params object[] args) {
			throw new UncaughtDispatchException ();
		}

		public bool dispatchIsValid(params object[] args) {
			return false;
		}

		public string dispatchDescription(params object[] args) {
			throw new UncaughtDispatchException ();
		}


		public static void dispatch(Dispatch exec, object[] args)
		{
			switch (args.Length) {
			case 0:
				return;

			case 1:
				(exec as dynamic).dispatch ((dynamic) args [0]);
				return;

			case 2:
				(exec as dynamic).dispatch ((dynamic) args [0], (dynamic) args[1]);
				return;

			case 3:
				(exec as dynamic).dispatch ((dynamic) args [0], (dynamic) args[1], (dynamic) args[2]);
				return;

			default:
				throw new ImplementationError ("Too many arguemnts.");
			}
		}


		public static bool isValid(Dispatch exec, object[] args)
		{
			switch (args.Length) {
			case 0:
				return false;

			case 1:
				return (exec as dynamic).dispatchIsValid ((dynamic) args [0]);

			case 2:
				return (exec as dynamic).dispatchIsValid ((dynamic) args [0], (dynamic) args[1]);

			case 3:
				return (exec as dynamic).dispatchIsValid ((dynamic) args [0], (dynamic) args[1], (dynamic) args[2]);

			default:
				throw new ImplementationError ("Too many arguemnts.");
			}
		}

		public static string getDescription(Dispatch exec, object[] args)
		{
			switch (args.Length) {
			case 0:
				throw new ImplementationError ();

			case 1:
				return (exec as dynamic).dispatchDescription ((dynamic) args [0]);

			case 2:
				return (exec as dynamic).dispatchDescription ((dynamic) args [0], (dynamic) args[1]);

			case 3:
				return (exec as dynamic).dispatchDescription ((dynamic) args [0], (dynamic) args[1], (dynamic) args[2]);

			default:
				throw new ImplementationError ("Too many arguemnts.");
			}
		}


		//
		//	Deprecated.  These perform poorly.
		//

		static public void _(dynamic arg1) {
			Instance.dispatch (arg1);
		}

		static public void _(dynamic arg1, dynamic arg2) {
			Instance.dispatch (arg1, arg2);
		}
	
		static public void _(dynamic arg1, dynamic arg2, dynamic arg3) {
			Instance.dispatch (arg1, arg2, arg3);
		}

		static public void _(dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4) {
			Instance.dispatch (arg1, arg2, arg3, arg4);
		}

		static public void _(dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4, dynamic arg5) {
			Instance.dispatch (arg1, arg2, arg3, arg4, arg5);
		}

		static public void _(dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4, dynamic arg5, dynamic arg6) {
			Instance.dispatch (arg1, arg2, arg3, arg4, arg5, arg6);
		}

	}
}

