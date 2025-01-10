using GameLogic.Components.Common;
using GameLogic.Models.Characters;
using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class JumpSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<JumpAction, Rigidbody2DLink, MotionConfigLink> _jumpActionFilter = null;
		private EcsFilter<JumpStateFlag> _jumpEndFilter = null;

		private float _minVerticalVelocity = 0.01f;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _jumpActionFilter)
			{
				ref EcsEntity entity = ref _jumpActionFilter.GetEntity (i);
				ref Rigidbody2D body = ref _jumpActionFilter.Get2 (i).Value;
				ref MotionConfig config = ref _jumpActionFilter.Get3 (i).Value;
				entity.Del<JumpAction> ();
				if (entity.Has<GroundedFlag> ())
				{
					AddJumpForce (body, config);
					entity.Get<JumpStateFlag> ();
					entity.Get<JumpAnimationFlag> ();
				}
				else if (entity.Has<JumpStateFlag> ())
				{
					AddJumpForce (body, config);
					entity.Del<JumpStateFlag> ();
					entity.Get<JumpAnimationFlag> ();
				}
			}

			foreach (int i in _jumpEndFilter)
			{
				ref EcsEntity entity = ref _jumpActionFilter.GetEntity (i);
				bool noVerticalVelocity = Mathf.Abs (entity.Get<Rigidbody2DLink> ().Value.velocity.y) < _minVerticalVelocity; // На случай, если после прыжка сразу же приземлились, не падая
				if (entity.Has<FallingFlag> () || noVerticalVelocity)
				{
					entity.Del<JumpStateFlag> ();
				}
			}
		}

		private void AddJumpForce ( Rigidbody2D body, MotionConfig config )
		{
			body.gravityScale = config.JumpGravityScale;
			body.AddForce (new Vector2 (0, config.JumpForce), ForceMode2D.Impulse);
		}
	}
}