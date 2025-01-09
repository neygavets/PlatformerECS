using UnityEditor;
using UnityEngine;

namespace Traps {
	public class TrapPoint : MonoBehaviour {
		[SerializeField] DamageZoneData data;

		public DamageZoneData Data { get => data; set => data = value; }

#if UNITY_EDITOR
		private void OnDrawGizmos () {
			Handles.color = new Color (1.0f, 0.5f, 0, 0.2f);
			Handles.DrawSolidDisc (transform.position, Vector3.forward, 0.5f);
			Handles.Label (transform.position, data.name);
		}
#endif
	}
}
