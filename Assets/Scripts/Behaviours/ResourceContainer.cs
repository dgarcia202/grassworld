using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Resources;

namespace Behaviours {
	public class ResourceContainer : MonoBehaviour {
	
		public int maxCapacity = 1000;
	
		public Dictionary<Resource, int> resources = new Dictionary<Resource, int>();

		void Start () {
		}

		void Update () {
		}

		public int Count(Resource resource) {
			if (this.resources.ContainsKey (resource)) {
				return this.resources [resource]; 
			}

			return 0;
		}

		public void Add(Resource resource, int amount) {
			if (this.resources.ContainsKey (resource)) {
				this.resources [resource] += amount;
				return;
			}

			this.resources.Add(resource, amount);
		}

		public int Take(Resource resource, int amount) {
			if (this.resources.ContainsKey (resource)) {
				if (this.resources [resource] >= amount) {
					this.resources [resource] -= amount;
					return amount;
				} else {
					var maxAmount = this.resources [resource];
					this.resources [resource] = 0;
					return maxAmount;
				}
			}

			return 0;
		}
	}
}
