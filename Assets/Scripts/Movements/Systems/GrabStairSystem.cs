using Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Movements {
	sealed class GrabStairSystem : IEcsRunSystem {
		// auto-injected fields.
		readonly EcsWorld _world = null;
		private EcsFilter<FreeMovingFlag, NearFacePointLink, LedgePointsLink, GameObjectLink>.Exclude<GrabStairStateFlag> canGrabFilter = null;
		private EcsFilter<GrabStairStateFlag> grabStateFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in canGrabFilter) {
				ref EcsEntity entity = ref canGrabFilter.GetEntity (i);
				ref GameObject gameObject = ref canGrabFilter.Get4 (i).Value;

				if (ObstacleChecker.CheckFront (gameObject.transform, canGrabFilter.Get2 (i).Point.position, LayerMasks.Stair)) {
					entity.Get<GrabStairStateFlag> ();
					entity.Get<GrabStairEnterAnimationFlag> ();
					if (entity.Has<HorizontalMovingFlag>())
						entity.Get<ChangeAxisMoving> ();		

					// Подтягиваем тело к "лестнице"
					RaycastHit2D toStairRay = Physics2D.Raycast (canGrabFilter.Get2 (i).Point.position, Vector2.right * gameObject.transform.localScale.x, 0.2f, LayerMasks.Stair);
					if (toStairRay.collider != null) {
						float distanceToStair = (Mathf.Abs (canGrabFilter.Get2 (i).Point.position.x - toStairRay.point.x) + 0.01f) * gameObject.transform.localScale.x;
						gameObject.transform.position = new Vector3 (gameObject.transform.position.x + distanceToStair, gameObject.transform.position.y, gameObject.transform.position.z);
					}
				}
			}
			foreach (int i in grabStateFilter) {
				ref EcsEntity entity = ref grabStateFilter.GetEntity (i);
				if (!ObstacleChecker.CheckFront (entity.Get<GameObjectLink>().Value.transform, entity.Get<NearFacePointLink> ().Point.transform.position, LayerMasks.Stair)) {
					entity.Del<GrabStairStateFlag> ();
					entity.Get<GrabStairExitAnimationFlag> ();
					entity.Get<ChangeAxisMoving> ();
				}
			}
		}
	}
}