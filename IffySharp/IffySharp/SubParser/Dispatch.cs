using System;

namespace IffySharp.SubParser
{

	public partial class Dispatch
	{
		private static readonly Dispatch singleton = new Dispatch();
		public Dispatch() {}
			
		public void dispatch(params dynamic[] args) {
			throw new UncaughtDispatchException ();
		}

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

