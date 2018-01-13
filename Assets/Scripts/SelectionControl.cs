using UnityEngine;
using System.Collections;

public class SelectionControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			// var select = GameObject.FindWithTag("select").transform;
			if (Physics.Raycast (ray, out hit, 100f)){
				// select.tag = "none";
				// hit.collider.transform.tag = "select";

				Debug.Log ("+++ selected obj " + hit.collider.gameObject.ToString());
			}
		}	
	}
}
