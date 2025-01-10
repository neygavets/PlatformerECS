using GameLogic.Components.Common;
using Leopotam.Ecs;
using GameLogic.Components.Movements;
using UnityEngine;

namespace GameLogic.Systems.Movements
{
	sealed class DirectionSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<Directed, Rigidbody2DLink> _directedBodyFilter = null;

		private readonly Vector3 FLIPPED_SCALE = new (-1, 1, 1);
		private const float MIN_FLIP_SPEED = 0.1f; // Минимальная скорость движения, при которой тело развернется в направлении этого движения

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _directedBodyFilter)
			{
				ref Rigidbody2D body = ref _directedBodyFilter.Get2 (i).Value;
				ref bool isFlipped = ref _directedBodyFilter.Get1 (i).isFlipped;
				if (body.velocity.x > MIN_FLIP_SPEED && isFlipped)
				{
					isFlipped = false;
					body.transform.localScale = Vector3.one;
				}
				if (body.velocity.x < -MIN_FLIP_SPEED && !isFlipped)
				{
					isFlipped = true;
					body.transform.localScale = FLIPPED_SCALE;
				}
			}
		}
	}
}