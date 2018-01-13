using UnityEngine;
using System.Collections;

public class HomeOwner : MonoBehaviour {

	public GameObject home;

	public Transform getHome() {

		if (home == null) {
			return null;
		}

		var rallyPoint = home.transform.FindChild ("RallyPoint");
		if (rallyPoint == null) {
			return null;
		}

		return rallyPoint.transform;
	}
}
