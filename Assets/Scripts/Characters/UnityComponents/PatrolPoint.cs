using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Characters {
	public class PatrolPoint : EnemyPoint {
		[SerializeField] Transform endPoint;

#if UNITY_EDITOR
		protected override void Visualization () {
			base.Visualization ();
			Handles.DrawSolidDisc (endPoint.position, Vector3.forward, 0.5f);
			Handles.Label (endPoint.position, "end point of patrol");
		}
#endif
	}
}
