using GameLogic.Components.Common;
using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class CheckFallingSystem : IEcsRunSystem
	{
		private EcsFilter<FreeMovingFlag, Rigidbody2DLink>.Exclude<GroundedFlag, VerticalMovingFlag> _checkedFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _checkedFilter)
			{
				ref EcsEntity entity = ref _checkedFilter.GetEntity (i);
				ref Rigidbody2D body = ref _checkedFilter.Get2 (i).Value;

				if (body.velocity.y < -1.0f && !entity.Has<FallingFlag> ())
				{
					entity.Get<FallingFlag> ();
					entity.Get<FallingAnimationFlag> ();
					if (entity.Has<MotionConfigLink> ())
						body.gravityScale = entity.Get<MotionConfigLink> ().Value.FallGravityScale;
				}
			}
		}
	}
}