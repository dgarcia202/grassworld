using UnityEngine;
using System;

using FSM.Core;
using Behaviours;
using Resources;

namespace FSM {
	public class HaulToWarehouseState : State {
		private static HaulToWarehouseState innerInstance;

		public static HaulToWarehouseState Instance {
			get {

				if (innerInstance == null) {
					innerInstance = new HaulToWarehouseState();
				}
				return innerInstance;
			}
		}

		private  HaulToWarehouseState () {
		}

		public override void OnEnter (StateMachine machine, UnityEngine.GameObject gameObject)
		{
			var agent = gameObject.GetComponent<NavMeshAgent> ();
			if (agent == null) {
				return;
			}

			var resourceGatherer = gameObject.GetComponent<ResourceGatherer> ();

			var possibleTargets = GameObject.FindGameObjectsWithTag ("Warehouse");
			if (possibleTargets.Length > 0) {
				agent.SetDestination (possibleTargets [0].transform.position); 
				resourceGatherer.TargetResource = possibleTargets [0];
				resourceGatherer.LastDiscoveredWarehouse = possibleTargets [0].transform.parent.gameObject;
			}
		}

		public override void OnUpdate (StateMachine machine, GameObject gameObject)
		{
			var agent = gameObject.GetComponent<NavMeshAgent> ();
			if (agent == null) {
				return;
			}			

			var resourceGatherer = gameObject.GetComponent<ResourceGatherer> ();
			var dist = Vector3.Distance (agent.transform.position, agent.destination);
			if (dist <= resourceGatherer.reachDistance) {
				
				var agentContainer = gameObject.GetComponent<ResourceContainer> ();
				var targetContainer = resourceGatherer.LastDiscoveredWarehouse.GetComponent<ResourceContainer> ();

				if (agentContainer == null || targetContainer == null) {
					machine.ChangeState (GoHomeState.Instance);
				}

				resourceGatherer.ResourceBuffer += resourceGatherer.unloadSpeed * Time.deltaTime;

				if (resourceGatherer.ResourceBuffer >= 1.0) {
					var integerAmount = Mathf.FloorToInt (resourceGatherer.ResourceBuffer);
					resourceGatherer.ResourceBuffer -= Mathf.Floor (resourceGatherer.ResourceBuffer);
					Transaction.Perform (agentContainer, targetContainer, Resource.Wood, integerAmount);
				}

				if (agentContainer.Count (Resource.Wood) == 0) {
					machine.ChangeState (GatherResourcesState.Instance);
				}
			}
		}
	}
}

