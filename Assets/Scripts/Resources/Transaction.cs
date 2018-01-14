using System;
using Behaviours;

namespace Resources
{
	public class Transaction
	{
		public static int Perform(ResourceContainer origin, ResourceContainer destination, ResourceType resource, int amount) {
			if (origin.Count (resource) < amount) {
				var availableAmount = origin.Count (resource);
				origin.Take (resource, availableAmount);
				destination.Add (resource, availableAmount);
				return availableAmount;
			}

			origin.Take (resource, amount);
			destination.Add (resource, amount);
			return amount;
		}
	}
}

