using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Behaviours;
using Resources;
using System.Text;
using System;

public class StorageProvider : MonoBehaviour {

	private ResourceContainer container;

	public Text storageInfoText;

	void Start () {
		this.container = this.GetComponent<ResourceContainer> ();
	}
	
	void Update () {

		var sb = new StringBuilder ();
		foreach (var res in this.container.NonEmptyResourceTypes) {
			sb.Append (res.Key.ToString());
			sb.Append (": ");
			sb.Append (res.Value.ToString());
			sb.Append (Environment.NewLine);
		}

		this.storageInfoText.text = sb.ToString();
	}
}
