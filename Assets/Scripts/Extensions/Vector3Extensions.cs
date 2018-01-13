using System;
using UnityEngine;

namespace Extensions
{
	public static class Vector3Extensions
	{
		public static GameObject FindNearest(this Vector3 position, GameObject[] candidates) {
			
			if (candidates.Length == 0) {
				return null;
			}

			float shortestDistance = Vector3.Distance (position, candidates[0].transform.position);
			GameObject nearest = candidates [0];
			for (int i = 1; i < candidates.Length; ++i) {
				var dist = Vector3.Distance (position, candidates[i].transform.position);
				if (dist < shortestDistance) {
					shortestDistance = dist;
					nearest = candidates[i];
				}
			}
			return nearest;			
		}
	}
}

