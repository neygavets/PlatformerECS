using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	sealed class CheckFallingSystem : IEcsRunSystem {
		private EcsFilter<FreeMovingFlag, Rigidbody2DLink>.Exclude<GroundedFlag, VerticalMovingFlag> checkedFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in checkedFilter) {
				ref EcsEntity entity = ref checkedFilter.GetEntity (i);
				ref Rigidbody2D body = ref checkedFilter.Get2 (i).Value;

				if (body.velocity.y < -1.0f && !entity.Has<FallingFlag> ()) {
					entity.Get<FallingFlag> ();			
					entity.Get<FallingAnimationFlag> ();					
					if (entity.Has<MotionConfigLink> ())
						body.gravityScale = entity.Get<MotionConfigLink> ().Value.FallGravityScale;
				}					
			}
		}
	}
}