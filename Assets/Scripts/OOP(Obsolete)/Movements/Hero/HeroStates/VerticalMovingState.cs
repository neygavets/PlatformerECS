using UnityEngine;

namespace OOP {
	public class VerticalMovingState : HeroMoveState {
		protected Vector2 velocity;
		protected float currentMoveAcceleration;
		protected float currentMaxMoveSpeed;

		public VerticalMovingState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			currentMoveAcceleration = heroMovement.settings.MoveAcceleration;
			currentMaxMoveSpeed = heroMovement.settings.MaxMoveSpeed;
			heroMovement.movableRigidbody.gravityScale = 0;
			heroMovement.moveInput = 0;
			heroMovement.movableRigidbody.velocity = Vector2.zero;

		}

		public override void Exit () {
			base.Exit ();
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
			// Берем текущую скорость тела
			velocity = heroMovement.movableRigidbody.velocity;
			// Добавляем к текущей скорости ускорение
			velocity.y += heroMovement.moveInput * heroMovement.transform.localScale.x * currentMoveAcceleration * Time.fixedDeltaTime;
			// можно так же обрабатывать Action напрямую
			//velocity.x += heroMovement.moveAction.ReadValue<float> () * heroMovement.settings.MoveAcceleration * Time.fixedDeltaTime;
			velocity.y = Mathf.Clamp (velocity.y, -currentMaxMoveSpeed, currentMaxMoveSpeed);
			heroMovement.movableRigidbody.velocity = velocity;
			heroMovement.animations.Launch (AnimationType.VerticalSpeed, velocity.y);
		}
	}
}
