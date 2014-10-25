using System;

namespace IffySharp.SubParser
{

	public partial class Dispatch
	{
		private static readonly Dispatch singleton = new Dispatch();

		//	Get the singleton.
		public Dispatch instance {
			get {
				return singleton;
			}
		}

		public Dispatch() {}
			
		public void dispatch(params object[] args) {
			throw new UncaughtDispatchException ();
		}



		//
		//	Deprecated.  These perform poorly.
		//

		static public void _(dynamic arg1) {
			singleton.dispatch (arg1);
		}

		static public void _(dynamic arg1, dynamic arg2) {
			singleton.dispatch (arg1, arg2);
		}
	
		static public void _(dynamic arg1, dynamic arg2, dynamic arg3) {
			singleton.dispatch (arg1, arg2, arg3);
		}

		static public void _(dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4) {
			singleton.dispatch (arg1, arg2, arg3, arg4);
		}

		static public void _(dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4, dynamic arg5) {
			singleton.dispatch (arg1, arg2, arg3, arg4, arg5);
		}

		static public void _(dynamic arg1, dynamic arg2, dynamic arg3, dynamic arg4, dynamic arg5, dynamic arg6) {
			singleton.dispatch (arg1, arg2, arg3, arg4, arg5, arg6);
		}

	}
}

