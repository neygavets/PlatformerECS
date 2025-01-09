using UnityEditor;
using UnityEngine;

namespace Characters {
	public class EnemyPoint : MonoBehaviour {
		[SerializeField] protected EnemyData data;

		public EnemyData Data { get => data; set => data = value; }

#if UNITY_EDITOR
		protected virtual void Visualization () {
			Handles.color = new Color (1.0f, 0, 0, 0.2f);
			Handles.DrawSolidDisc (transform.position, Vector3.forward, 0.5f);
			Handles.Label (transform.position, data.name);
		}

		protected void OnDrawGizmos () {
			Visualization ();			
		}
#endif
	}
}