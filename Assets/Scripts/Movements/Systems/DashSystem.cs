using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	sealed class DashSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<DashAction, Rigidbody2DLink, HorizontalMovingFlag> dashActionFilter = null;
		private EcsFilter<DashState, Rigidbody2DLink, MotionConfigLink> dashStateFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in dashActionFilter) {
				ref EcsEntity entity = ref dashActionFilter.GetEntity (i);
				entity.Del<DashAction> ();
				if (entity.Has<DashState> () || !entity.Has<FreeMovingFlag>())
					return;
				entity.Get<DashState> () = new DashState { Duration = 0.2f };
				dashActionFilter.Get2 (i).Value.velocity = Vector2.zero;				
			}

			foreach (int i in dashStateFilter) {
				ref EcsEntity entity = ref dashStateFilter.GetEntity (i);				
				if (entity.Get<DashState>().Duration <= 0) {
					entity.Del<DashState> ();
					return;
				}
				Rigidbody2D body = dashStateFilter.Get2 (i).Value;
				body.AddForce (Vector2.right * body.transform.localScale.x * dashStateFilter.Get3 (i).Value.DashAcceleration, ForceMode2D.Force);
				body.velocity = new Vector2 (body.velocity.x, 0.0f);
				entity.Get<DashState> ().Duration -= Time.deltaTime;
			}
		}
	}
}