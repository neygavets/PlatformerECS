using GameLogic.Components.Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class DuckSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<DuckAction, Collider2DLink, PhysicalBodySizeLink> _duckFilter = null;

		private const float HEAD_RADIUS = 0.18f;
		private const float HEAD_OFFSET = 0.05f;
		private LayerMask _groundedMask = LayerMask.GetMask ("Ground", "Wall");

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _duckFilter)
			{
				ref EcsEntity entity = ref _duckFilter.GetEntity (0);
				entity.Del<DuckAction> ();

				if (!entity.Has<FreeMovingFlag> ())
					return;

				if (entity.Has<DuckStateFlag> ())
				{
					Vector2 headPoint = new Vector2 (_duckFilter.Get2 (i).Value.transform.position.x, _duckFilter.Get2 (i).Value.transform.position.y + _duckFilter.Get3 (i).Size.y - HEAD_OFFSET);
					if (!Physics2D.OverlapCircle (headPoint, HEAD_RADIUS, _groundedMask))
					{
						Collider2DUtils.SetSize (ref _duckFilter.Get2 (i).Value, _duckFilter.Get3 (i).Size);
						_duckFilter.Get2 (i).Value.offset = _duckFilter.Get3 (i).Offset;
						entity.Del<DuckStateFlag> ();
						entity.Get<DuckExitAnimationFlag> ();
					}
				}
				else
				{
					entity.Get<DuckStateFlag> ();
					entity.Get<DuckEnterAnimationFlag> ();
					Collider2DUtils.SetSize (ref _duckFilter.Get2 (i).Value, new Vector2 (_duckFilter.Get3 (i).Size.x, _duckFilter.Get3 (i).Size.y / 2f));
					_duckFilter.Get2 (i).Value.offset = new Vector2 (_duckFilter.Get3 (i).Offset.x, _duckFilter.Get3 (i).Offset.y + (_duckFilter.Get3 (i).Size.y / 2f - _duckFilter.Get3 (i).Size.y) / 2f);
				}
			}
		}

	}
}