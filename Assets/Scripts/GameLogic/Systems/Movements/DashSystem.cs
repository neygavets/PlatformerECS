using GameLogic.Components.Common;
using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class DashSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<DashAction, Rigidbody2DLink, HorizontalMovingFlag> _dashActionFilter = null;
		private EcsFilter<DashState, Rigidbody2DLink, MotionConfigLink> _dashStateFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _dashActionFilter)
			{
				ref EcsEntity entity = ref _dashActionFilter.GetEntity (i);
				entity.Del<DashAction> ();
				if (entity.Has<DashState> () || !entity.Has<FreeMovingFlag> ())
					return;
				entity.Get<DashState> () = new DashState { Duration = 0.2f };
				_dashActionFilter.Get2 (i).Value.velocity = Vector2.zero;
			}

			foreach (int i in _dashStateFilter)
			{
				ref EcsEntity entity = ref _dashStateFilter.GetEntity (i);
				if (entity.Get<DashState> ().Duration <= 0)
				{
					entity.Del<DashState> ();
					return;
				}

				Rigidbody2D body = _dashStateFilter.Get2 (i).Value;
				body.AddForce (_dashStateFilter.Get3 (i).Value.DashAcceleration * body.transform.localScale.x * Vector2.right, ForceMode2D.Force);
				body.velocity = new Vector2 (body.velocity.x, 0.0f);
				entity.Get<DashState> ().Duration -= Time.deltaTime;
			}
		}
	}
}