using UnityEngine;

namespace Utils {
	public static class Collider2DUtils {

		/// <summary>
		/// Use only with CapsuleCollider2D or BoxCollider2D
		/// </summary>
		public static Vector2 GetSize (Collider2D collider) {
			if (collider.GetType () == typeof (CapsuleCollider2D)) {
				return ((CapsuleCollider2D) collider).size;
			}
			if (collider.GetType () == typeof (BoxCollider2D)) {
				return ((BoxCollider2D)collider).size;
			}
			Debug.Log ("This collider has a complex shape, function returned a zero vector.");
			return Vector2.zero;
		}

		/// <summary>
		/// Use only with CapsuleCollider2D or BoxCollider2D
		/// </summary>
		public static void SetSize (ref Collider2D collider, Vector2 size) {
			if (collider.GetType () == typeof (CapsuleCollider2D)) {
				((CapsuleCollider2D)collider).size = size;
			}
			if (collider.GetType () == typeof (BoxCollider2D)) {
				((BoxCollider2D)collider).size = size;
			}
		}
	}
}
