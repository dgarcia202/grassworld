using System;
using UnityEngine;

namespace FSM.Core
{
	public abstract class State
	{
		public virtual void OnEnter (StateMachine machine, GameObject gameObject) {
		}

		public virtual void OnExit (StateMachine machine, GameObject gameObject) {
		}

		public virtual void OnUpdate (StateMachine machine, GameObject gameObject) {
		}
	}
}

