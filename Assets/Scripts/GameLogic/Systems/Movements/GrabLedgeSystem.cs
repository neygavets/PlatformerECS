using Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Movements {
	sealed class GrabLedgeSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<FreeMovingFlag, NearFacePointLink, LedgePointsLink, GameObjectLink> canGrabFilter = null;
		private EcsFilter<PullUpAction, Velocity> grabStateFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in canGrabFilter) {
				ref EcsEntity entity = ref canGrabFilter.GetEntity (i);
				Transform nearFacePoint = canGrabFilter.Get2 (i).Point;
				Transform ledgePoint = canGrabFilter.Get3 (i).PointBefore;
				ref GameObject gameObject = ref canGrabFilter.Get4 (i).Value;

				// чекаем обычный уступ стены
				if (ObstacleChecker.CheckLedge (gameObject.transform, nearFacePoint.position, ledgePoint.position, LayerMasks.Wall)) {
					SetState (ref entity, ledgePoint, ref gameObject);
					return;
				}
				// чекаем уступ "лестницы"
				if (ObstacleChecker.CheckLedge (gameObject.transform, nearFacePoint.position, ledgePoint.position, LayerMasks.Stair)) {
					if (entity.Has<GrabStairStateFlag> ()) {
						entity.Del<GrabStairStateFlag> ();
						entity.Del<VerticalMovingFlag> ();
						entity.Get<GrabStairExitAnimationFlag> ();
					}
					SetState (ref entity, ledgePoint, ref gameObject);
				}
			}

			foreach (int i in grabStateFilter) {
				ref EcsEntity entity = ref grabStateFilter.GetEntity (i);
				ref GameObject gameObject = ref entity.Get<GameObjectLink> ().Value;
				entity.Del<PullUpAction> ();
				entity.Del<GrabLedgeStateFlag> ();
				if (grabStateFilter.Get2 (i).Value == gameObject.transform.localScale.x) {
					entity.Get<PullUpAnimationFlag> ();
				} else {
					entity.Get<FreeMovingFlag> ();
					entity.Get<HorizontalMovingFlag> ();
					// Сместим тело по оси Y вниз на величину расстояния между точками, проверяющими наличие уступа
					Vector3 offset = new Vector3 (0.0f, (entity.Get<LedgePointsLink> ().PointBefore.position - entity.Get<LedgePointsLink> ().PointBehind.position).y, 0.0f);
					gameObject.transform.position += offset;
					if (entity.Has<Rigidbody2DLink> ())
						entity.Get<Rigidbody2DLink> ().Value.gravityScale = 1;
				}
			}
		}

		private void SetState ( ref EcsEntity entity, Transform ledgePoint, ref GameObject gameObject ) {
			entity.Del<FreeMovingFlag> ();
			entity.Del<HorizontalMovingFlag> ();
			entity.Del<FallingFlag> ();
			entity.Del<GroundedFlag> ();
			entity.Get<GrabLedgeAnimationFlag> ();
			entity.Get<GrabLedgeStateFlag> ();

			// Тело должно "зависнуть" - убираем все действующие на него силы
			if (entity.Has<Rigidbody2DLink> ()) {
				ref Rigidbody2D body = ref entity.Get<Rigidbody2DLink> ().Value;
				body.gravityScale = 0;
				body.velocity = Vector2.zero;
			}
			// Подгоняем точку захвата точно на нужное место
			float raycastDistance = 0.2f;
			RaycastHit2D overheadRay = Physics2D.Raycast (ledgePoint.position + new Vector3 (raycastDistance, 0, 0) * gameObject.transform.localScale.y, Vector2.down * gameObject.transform.localScale.x, raycastDistance, LayerMasks.Ground);
			if (overheadRay.collider != null) {
				float distanceToGround = ledgePoint.position.y - overheadRay.point.y;
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - distanceToGround + 0.01f, gameObject.transform.position.z);
			}
		}
	}
}