using GameLogic.Components.Common;
using Leopotam.Ecs;
using GameLogic.Components.Movements;
using UnityEngine;

namespace GameLogic.Systems.Movements
{
	sealed class ChangeAxisSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<ChangeAxisMoving> _changeAxisFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _changeAxisFilter)
			{
				ref EcsEntity entity = ref _changeAxisFilter.GetEntity (i);
				bool hasRigidbody2D = entity.Has<Rigidbody2DLink> ();
				entity.Del<ChangeAxisMoving> ();
				if (entity.Has<VerticalMovingFlag> ())
				{
					entity.Del<VerticalMovingFlag> ();
					entity.Get<VerticalSpeedAnimation> ().Value = 0.0f;
					entity.Get<HorizontalMovingFlag> ();
					if (hasRigidbody2D)
						entity.Get<Rigidbody2DLink> ().Value.gravityScale = 1.0f;
				}
				else if (entity.Has<HorizontalMovingFlag> ())
				{
					entity.Del<HorizontalMovingFlag> ();
					entity.Del<FallingFlag> ();
					entity.Get<HorizontalSpeedAnimation> ().Value = 0.0f;
					entity.Get<VerticalMovingFlag> ();
					if (hasRigidbody2D)
					{
						ref Rigidbody2D body = ref entity.Get<Rigidbody2DLink> ().Value;
						body.gravityScale = 0.0f;
						body.velocity = Vector2.zero;
					}
				}
			}
		}
	}
}