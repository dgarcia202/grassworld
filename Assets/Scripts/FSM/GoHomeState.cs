using UnityEngine;
using System.Collections;
using FSM.Core;

namespace FSM
{
	public class GoHomeState : State
	{
		private static GoHomeState innerInstance;

		public static GoHomeState Instance {
			get {

				if (innerInstance == null) {
					innerInstance = new GoHomeState();
				}
				return innerInstance;
			}
		}

		private GoHomeState() {
		}

		public override void OnEnter (StateMachine machine, GameObject gameObject)
		{
			var agent = gameObject.GetComponent<NavMeshAgent> ();
			if (agent == null) {
				return;
			}

			var haveHomeBehavior = gameObject.GetComponent<HomeOwner> ();
			if (haveHomeBehavior == null) {
				return;
			}

			var targetTransform = haveHomeBehavior.getHome ();
			if (targetTransform == null) {
				return;
			}

			agent.SetDestination (targetTransform.position); 
		}
			
		public override void OnUpdate (StateMachine machine, GameObject gameObject)
		{
			var agent = gameObject.GetComponent<NavMeshAgent> ();
			if (agent == null) {
				return;
			}

			var dist = Vector3.Distance (agent.transform.position, agent.destination);

			if (dist <= 1.5f) {
				machine.ChangeState (GatherResourcesState.Instance);
			}
		}
	}
}
