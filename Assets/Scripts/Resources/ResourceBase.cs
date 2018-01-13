using UnityEngine;
using System.Collections;

namespace Resources
{
	public abstract class ResourceBase
	{
	
		protected string displayName;

		public string DisplayName {
			get {
				return this.displayName;	
			}
		}

		protected ResourceBase (string displayName)
		{
			this.displayName = displayName;
		}

		public override bool Equals (object obj)
		{
			return this.DisplayName == (obj as ResourceBase).DisplayName;
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public override string ToString ()
		{
			return this.DisplayName;
		}
	}
}
