using UnityEngine;

namespace Utils
{
	/// <summary>
	/// Методы нахождения различных препятствий
	/// </summary>
	public static class ObstacleChecker
	{
		const float CHECK_OBSTACLE_DISTANCE = 0.2f;
		const float MIN_OFFSET = 0.01f;

		public static bool CheckUnderfoot ( Vector3 position, float bodyWidth, int layerMask ) =>
			Physics2D.CircleCast (position + Vector3.up * CHECK_OBSTACLE_DISTANCE, bodyWidth / 2 - MIN_OFFSET, Vector2.down, CHECK_OBSTACLE_DISTANCE * 2, layerMask);

		public static bool CheckLedge ( Transform transform, Vector3 pointFront, Vector3 pointTop, int layerMask ) =>
			Physics2D.Raycast (pointFront, Vector2.right * transform.localScale.x, CHECK_OBSTACLE_DISTANCE, layerMask) && !Physics2D.Raycast (pointTop, Vector2.right * transform.localScale.x, CHECK_OBSTACLE_DISTANCE, layerMask);

		public static bool CheckFront ( Transform transform, Vector3 pointFront, int layerMask ) =>
			 Physics2D.Raycast (pointFront, Vector2.right * transform.localScale.x, CHECK_OBSTACLE_DISTANCE, layerMask);
	}
}