﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using Behaviours;
using Resources;

public class TreeWoodProvider : MonoBehaviour {

	private ResourceContainer container;

	// Use this for initialization
	void Start () {
		this.container = this.GetComponent<ResourceContainer> ();
		var random = Random.Range (1, 7);
		container.Add (Resource.Wood, 30 + (random * 10));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
