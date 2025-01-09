using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	sealed class HorizontalMoveSystem : IEcsRunSystem {
		// auto-injected fields.		
		private EcsFilter<HorizontalMovingFlag, Velocity, Rigidbody2DLink, MotionConfigLink> movableObjectFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in movableObjectFilter) {
				ref EcsEntity entity = ref movableObjectFilter.GetEntity (i);
				MotionConfig config = movableObjectFilter.Get4 (i).Value;
				ref Rigidbody2D body = ref movableObjectFilter.Get3 (i).Value;
				
				// ����� ������� �������� ����
				Vector2 velocity = body.velocity;
				// ��������� � ������� �������� ���������
				velocity.x += movableObjectFilter.Get2 (i).Value * config.MoveAcceleration * Time.fixedDeltaTime;
				// ������������ �������� ������������� ���������� �� ��������
				velocity.x = Mathf.Clamp (velocity.x, -config.MaxMoveSpeed, config.MaxMoveSpeed);
				// ������ ���� ����� ��������
				body.velocity = velocity;
				entity.Get<HorizontalSpeedAnimation> ().Value = velocity.x;
			}
		}
	}
}