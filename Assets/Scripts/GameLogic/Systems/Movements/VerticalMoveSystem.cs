using GameLogic.Components.Common;
using GameLogic.Models.Characters;
using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class VerticalMoveSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<VerticalMovingFlag, Velocity, Rigidbody2DLink, MotionConfigLink> _movableObjectFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _movableObjectFilter)
			{
				ref EcsEntity entity = ref _movableObjectFilter.GetEntity (i);
				MotionConfig config = _movableObjectFilter.Get4 (i).Value;
				ref Rigidbody2D body = ref _movableObjectFilter.Get3 (i).Value;
				float input = _movableObjectFilter.Get2 (i).Value;

				// Берем текущую скорость тела
				Vector2 velocity = body.velocity;
				if (input == 0)
				{
					//если ввода нет, остановиться (убираем движение по инерции)
					velocity = Vector2.zero;
				}
				else
				{
					// Добавляем к текущей скорости ускорение
					velocity.y += input * body.transform.localScale.x * config.MoveAcceleration * Time.fixedDeltaTime;
					// Ограничиваем скорость максимальными значениями из настроек
					velocity.y = Mathf.Clamp (velocity.y, -config.MaxMoveSpeed, config.MaxMoveSpeed);
					velocity.x = 0.0f;
				}
				// Отдаем телу новую скорость
				body.velocity = velocity;
				entity.Get<VerticalSpeedAnimation> ().Value = velocity.y;
			}
		}
	}
}