using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Behaviours;
using Resources;

public class StorageProvider : MonoBehaviour {

	private ResourceContainer container;

	public Text debugText;

	// Use this for initialization
	void Start () {
		this.container = this.GetComponent<ResourceContainer> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.debugText.text = "waregouse: " + this.container.Count (Resource.Wood);
	}
}
