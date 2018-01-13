using UnityEngine;
using System.Collections;

using FSM.Core;
using Behaviours;
using Resources;

namespace FSM
{
	public class GatherResourcesState : State
	{
		private static GatherResourcesState innerInstance;

		public static GatherResourcesState Instance {
			get {
				
				if (innerInstance == null) {
					innerInstance = new GatherResourcesState();
				}
				return innerInstance;
			}
		}

		private GatherResourcesState() {
		}

		public override void OnEnter (StateMachine machine, GameObject gameObject) {
			
			var agent = gameObject.GetComponent<NavMeshAgent> ();
			if (agent == null) {
				machine.ChangeState (IdleState.Instance);
				return;
			}

			var resourceGatherer = gameObject.GetComponent<ResourceGatherer> ();
			var nearest = FindNearestResorce (gameObject.transform.position);

			if (nearest != null) {
				agent.SetDestination (nearest.transform.position); 
				resourceGatherer.TargetResource = nearest;
			} else {
				machine.ChangeState (IdleState.Instance);
			}
		}

		public override void OnUpdate (StateMachine machine, GameObject gameObject) {
			var agent = gameObject.GetComponent<NavMeshAgent> ();
			if (agent == null) {
				return;
			}

			var resourceGatherer = gameObject.GetComponent<ResourceGatherer> ();
			var dist = Vector3.Distance (agent.transform.position, agent.destination);
			if (dist <= resourceGatherer.reachDistance) {

				var targetContainer = resourceGatherer.TargetResource.GetComponent<ResourceContainer>();
				var agentContainer = gameObject.GetComponent<ResourceContainer> ();

				if (agentContainer == null || targetContainer == null) {
					machine.ChangeState (GoHomeState.Instance);
					return;
				}

				resourceGatherer.ResourceBuffer += resourceGatherer.harvestSpeed * Time.deltaTime;

				if (resourceGatherer.ResourceBuffer >= 1.0f) {
					var integerAmount = Mathf.FloorToInt (resourceGatherer.ResourceBuffer);
					resourceGatherer.ResourceBuffer -= Mathf.Floor (resourceGatherer.ResourceBuffer);
					Transaction.Perform (targetContainer, agentContainer, Resource.Wood, integerAmount);

					if (targetContainer.Count(Resource.Wood) == 0) {
						Object.Destroy (resourceGatherer.TargetResource);
					}

					if (agentContainer.Count (Resource.Wood) >= agentContainer.maxCapacity) {
						resourceGatherer.ResourceBuffer = 0;
						machine.ChangeState (HaulToWarehouseState.Instance);
					}
				}
			}
		}

		private GameObject FindNearestResorce (Vector3 currentPosition)
		{
			var possibleTargets = GameObject.FindGameObjectsWithTag ("Resource");

			if (possibleTargets.Length == 0) {
				return null;
			}

			float shortestDistance = Vector3.Distance (currentPosition, possibleTargets [0].transform.position);
			GameObject nearest = possibleTargets [0];
			foreach (GameObject candidate in possibleTargets) {
				var dist = Vector3.Distance (currentPosition, candidate.transform.position);
				if (dist < shortestDistance) {
					shortestDistance = dist;
					nearest = candidate;
				}
			}
			return nearest;
		}
	}
}
