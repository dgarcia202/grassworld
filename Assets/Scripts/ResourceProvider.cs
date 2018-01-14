using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using Behaviours;
using Resources;

public class ResourceProvider : MonoBehaviour {

	private ResourceContainer container;

	public ResourceType resourceType;

	public int minInitialStock = 0;

	public int maxInitialStock = 50;

	void Start () {
		this.container = this.GetComponent<ResourceContainer> ();

		var initialStock = this.minInitialStock;
		if (this.minInitialStock != this.maxInitialStock) {
			initialStock = this.minInitialStock + Random.Range (0, this.maxInitialStock - this.minInitialStock);
		}
			
		container.Add (this.resourceType, initialStock);
	}
	
	void Update () {
	}
}
