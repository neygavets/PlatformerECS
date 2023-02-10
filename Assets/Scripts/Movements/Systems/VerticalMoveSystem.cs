using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	sealed class VerticalMoveSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<VerticalMovingFlag, Velocity, Rigidbody2DLink, MotionConfigLink> movableObjectFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in movableObjectFilter) {
				ref EcsEntity entity = ref movableObjectFilter.GetEntity (i);
				MotionConfig config = movableObjectFilter.Get4 (i).Value;
				ref Rigidbody2D body = ref movableObjectFilter.Get3 (i).Value;
				float input = movableObjectFilter.Get2 (i).Value;

				// ����� ������� �������� ����
				Vector2 velocity = body.velocity;
				if (input == 0) {
					//���� ����� ���, ������������ (������� �������� �� �������)
					velocity = Vector2.zero;
				} else {
					// ��������� � ������� �������� ���������
					velocity.y += input * body.transform.localScale.x * config.MoveAcceleration * Time.fixedDeltaTime;
					// ������������ �������� ������������� ���������� �� ��������
					velocity.y = Mathf.Clamp (velocity.y, -config.MaxMoveSpeed, config.MaxMoveSpeed);
					velocity.x = 0.0f;
				}				
				// ������ ���� ����� ��������
				body.velocity = velocity;
				entity.Get<VerticalSpeedAnimation> ().Value = velocity.y;
			}
		}
	}
}