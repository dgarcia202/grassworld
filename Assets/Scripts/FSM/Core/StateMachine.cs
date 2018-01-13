using System;
using UnityEngine;

namespace FSM.Core
{
	public class StateMachine {
		
		private GameObject owner { get; set; }

		State CurrentState { get; set; }

		State PreviousState { get; set; }

		State GlobalState { get; set; }

		public StateMachine (GameObject owner) {
			this.owner = owner;
		}

		public void OnUpdate() {
			if (GlobalState != null) {
				GlobalState.OnUpdate (this, owner);
			}

			if (CurrentState != null) {
				CurrentState.OnUpdate (this, owner);
			}
		}

		public void ChangeState(State state) {
			if (state == null) {
				return;
			}

			if (CurrentState != null) {
				PreviousState = CurrentState;
				CurrentState.OnExit (this, owner);
			}

			CurrentState = state;
			CurrentState.OnEnter (this, owner);
		}

		public void RevertToPreviousState()
		{
			ChangeState(this.PreviousState);
		}

		public bool IsInState(State state)
		{
			return CurrentState == state;
		}
	}
}

