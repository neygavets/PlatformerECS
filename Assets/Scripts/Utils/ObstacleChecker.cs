using UnityEngine;

namespace Utils {
	public static class ObstacleChecker {
		const float checkObstacleDistance = 0.2f;
		const float minOffset = 0.01f;

		public static bool CheckUnderfoot ( Vector3 position, float bodyWidth, int layerMask ) =>
			Physics2D.CircleCast (position + Vector3.up * checkObstacleDistance, bodyWidth / 2 - minOffset, Vector2.down, checkObstacleDistance * 2, layerMask);

		public static bool CheckLedge ( Transform transform, Vector3 pointFront, Vector3 pointTop, int layerMask ) =>
			Physics2D.Raycast (pointFront, Vector2.right * transform.localScale.x, checkObstacleDistance, layerMask) && !Physics2D.Raycast (pointTop, Vector2.right * transform.localScale.x, checkObstacleDistance, layerMask);

		public static bool CheckFront ( Transform transform, Vector3 pointFront, int layerMask ) =>
			 Physics2D.Raycast (pointFront, Vector2.right * transform.localScale.x, checkObstacleDistance, layerMask);
	}
}