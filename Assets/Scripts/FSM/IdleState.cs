using System;
using FSM.Core;

namespace FSM {
	public class IdleState  : State {
		private static IdleState innerInstance;

		public static IdleState Instance {
			get {

				if (innerInstance == null) {
					innerInstance = new IdleState();
				}
				return innerInstance;
			}
		}

		private IdleState ()	{
		}
	}
}

