using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Characters {

	public class GuardPoint : EnemyPoint {
		[SerializeField] bool flippedToLeft;

		public float Direction { 
			get => flippedToLeft ? -1 : 1;
		}

#if UNITY_EDITOR
		protected override void Visualization () {
			base.Visualization();
			float angle = 45.0f;
			Vector3 origin = transform.position;
			Vector3 posUp = origin + (Quaternion.Euler (0, 0, angle * 0.5f) * Vector3.right * Direction);
			Vector3 posDown = origin + (Quaternion.Euler (0, 0, -angle * 0.5f) * Vector3.right * Direction);

			Vector3 cross = Vector3.Cross (posUp - origin, posDown - origin);

			Handles.color = new Color (0, 1.0f, 0, 0.2f);
			Handles.DrawSolidArc (origin, cross, posUp - origin, angle, 1.0f);
		}
#endif
	}
}