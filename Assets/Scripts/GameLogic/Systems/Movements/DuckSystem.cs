using Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Movements {
	sealed class DuckSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<DuckAction, Collider2DLink, PhysicalBodySizeLink> duckFilter = null;

		private float headRadius = 0.18f;
		private float headOffset = 0.05f;
		private LayerMask groundedMask = LayerMask.GetMask ("Ground", "Wall");

		void IEcsRunSystem.Run () {
			foreach (int i in duckFilter) {
				ref EcsEntity entity = ref duckFilter.GetEntity (0);
				entity.Del<DuckAction> ();
				if (!entity.Has<FreeMovingFlag> ())
					return;

				if (entity.Has<DuckStateFlag> ()) {
					Vector2 headPoint = new Vector2 (duckFilter.Get2(i).Value.transform.position.x, duckFilter.Get2 (i).Value.transform.position.y + duckFilter.Get3(i).Size.y - headOffset);
					if (!Physics2D.OverlapCircle (headPoint, headRadius, groundedMask)) {
						Collider2DUtils.SetSize (ref duckFilter.Get2 (i).Value, duckFilter.Get3 (i).Size);
						duckFilter.Get2 (i).Value.offset = duckFilter.Get3 (i).Offset;
						entity.Del<DuckStateFlag> ();
						entity.Get<DuckExitAnimationFlag> ();
					}
				} else {
					entity.Get<DuckStateFlag> ();
					entity.Get<DuckEnterAnimationFlag> ();
					Collider2DUtils.SetSize(ref duckFilter.Get2 (i).Value, new Vector2 (duckFilter.Get3 (i).Size.x, duckFilter.Get3 (i).Size.y / 2f));
					duckFilter.Get2 (i).Value.offset = new Vector2 (duckFilter.Get3 (i).Offset.x, duckFilter.Get3 (i).Offset.y + (duckFilter.Get3 (i).Size.y / 2f - duckFilter.Get3 (i).Size.y) / 2f);
				}
			}
		}

	}
}