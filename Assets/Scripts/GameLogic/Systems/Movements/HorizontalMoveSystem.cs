using GameLogic.Components.Common;
using GameLogic.Models.Characters;
using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class HorizontalMoveSystem : IEcsRunSystem
	{
		// auto-injected fields.		
		private EcsFilter<HorizontalMovingFlag, Velocity, Rigidbody2DLink, MotionConfigLink> _movableObjectFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _movableObjectFilter)
			{
				ref EcsEntity entity = ref _movableObjectFilter.GetEntity (i);
				MotionConfig config = _movableObjectFilter.Get4 (i).Value;
				ref Rigidbody2D body = ref _movableObjectFilter.Get3 (i).Value;

				// Берем текущую скорость тела
				Vector2 velocity = body.velocity;
				// Добавляем к текущей скорости ускорение
				velocity.x += _movableObjectFilter.Get2 (i).Value * config.MoveAcceleration * Time.fixedDeltaTime;
				// Ограничиваем скорость максимальными значениями из настроек
				velocity.x = Mathf.Clamp (velocity.x, -config.MaxMoveSpeed, config.MaxMoveSpeed);
				// Отдаем телу новую скорость
				body.velocity = velocity;
				entity.Get<HorizontalSpeedAnimation> ().Value = velocity.x;
			}
		}
	}
}