using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using FSM.Core;
using FSM;
using Behaviours;
using Resources;

public class ResourceGatherer : MonoBehaviour {

	private StateMachine machine;

	private ResourceContainer container;

	private GameObject targetResource;

	private GameObject lastDiscoveredWarehouse;

	/// <summary>
	/// Fractional amount of the resource currently being harvested.
	/// </summary>
	private float resourceBuffer = 0.0f;

	/// <summary>
	/// In units per second.
	/// </summary>
	public float harvestSpeed = 1.0f;

	public float unloadSpeed = 4.0f;

	public float reachDistance = 2.0f;

	public Text debugText;

	public GameObject TargetResource {
		get {
			return targetResource;
		}
		set {
			targetResource = value;
		}
	}

	public float ResourceBuffer {
		get {
			return resourceBuffer;
		}
		set {
			resourceBuffer = value;
		}
	}

	public GameObject LastDiscoveredWarehouse {
		get {
			return lastDiscoveredWarehouse;
		}
		set {
			lastDiscoveredWarehouse = value;
		}
	}

	void Start () {
		machine = new StateMachine (this.gameObject);
		machine.ChangeState (GatherResourcesState.Instance);

		this.container = this.GetComponent<ResourceContainer> ();
	}

	void Update () {
		machine.OnUpdate ();
		debugText.text = "agent: " + this.container.Count(ResourceType.Wood);
	}
}
