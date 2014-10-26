using System;

namespace IffySharp.SubParser
{

	public partial class Dispatch
	{
		public static readonly Dispatch Instance = new Dispatch();


		public Dispatch() {}
			
		public void dispatch(params object[] args) {
			throw new UncaughtDispatchException ();
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

