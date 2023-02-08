using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	sealed class JumpSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<JumpAction, Rigidbody2DLink, MotionConfigLink> jumpActionFilter = null;
		private EcsFilter<JumpStateFlag> jumpEndFilter = null;

		float minVerticalVelocity = 0.01f;

		void IEcsRunSystem.Run () {
			foreach (int i in jumpActionFilter) {
				ref EcsEntity entity = ref jumpActionFilter.GetEntity (i);
				ref Rigidbody2D body = ref jumpActionFilter.Get2 (i).Value;
				ref MotionConfig config = ref jumpActionFilter.Get3 (i).Value;
				entity.Del<JumpAction> ();				
				if (entity.Has<GroundedFlag> ()) {
					AddJumpForce (body, config);
					entity.Get<JumpStateFlag> ();
					entity.Get<JumpAnimationFlag> ();
				} else	if (entity.Has<JumpStateFlag> ()) {
					AddJumpForce (body, config);
					entity.Del<JumpStateFlag> ();
					entity.Get<JumpAnimationFlag> ();
				}
			}
			foreach (int i in jumpEndFilter) {
				ref EcsEntity entity = ref jumpActionFilter.GetEntity (i);
				bool noVerticalVelocity = Mathf.Abs (entity.Get<Rigidbody2DLink> ().Value.velocity.y) < minVerticalVelocity; // На случай, если после прыжка сразу же приземлились, не падая
				if (entity.Has<FallingFlag> () || noVerticalVelocity) {
					entity.Del<JumpStateFlag> ();
				}
			}
		}

		private void AddJumpForce ( Rigidbody2D body, MotionConfig config ) {			
			body.gravityScale = config.JumpGravityScale;
			body.AddForce (new Vector2 (0, config.JumpForce), ForceMode2D.Impulse);
		}
	}
}