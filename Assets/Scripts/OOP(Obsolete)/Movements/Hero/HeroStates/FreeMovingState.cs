using UnityEngine;

namespace OOP {
	public class FreeMovingState : HeroMoveState {
		protected Vector2 velocity;
		protected float currentMoveAcceleration;
		protected float currentMaxMoveSpeed;
		private bool isFalling;

		public FreeMovingState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			currentMoveAcceleration = heroMovement.settings.MoveAcceleration;
			currentMaxMoveSpeed = heroMovement.settings.MaxMoveSpeed;
			isFalling = false;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.animations.Launch (AnimationType.HorizontalSpeed, 0);
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
			if (isFalling && stateMachine.CurrentState != heroMovement.fallState)
				stateMachine.ChangeState (heroMovement.fallState);
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
			// Берем текущую скорость тела
			velocity = heroMovement.movableRigidbody.velocity;
			// Добавляем к текущей скорости ускорение
			velocity.x += heroMovement.moveInput * currentMoveAcceleration * Time.fixedDeltaTime;
			// можно так же обрабатывать Action напрямую
			//velocity.x += heroMovement.moveAction.ReadValue<float> () * heroMovement.settings.MoveAcceleration * Time.fixedDeltaTime;
			velocity.x = Mathf.Clamp (velocity.x, -currentMaxMoveSpeed, currentMaxMoveSpeed);
			heroMovement.movableRigidbody.velocity = velocity;
			heroMovement.animations.Launch (AnimationType.HorizontalSpeed, Mathf.Abs (velocity.x));
			heroMovement.direction.UpdateDirection ();
			heroMovement.UpdateGravityScale ();

			// Устанавливаем флаг, если находимся в падении
			isFalling = heroMovement.movableRigidbody.velocity.y < -1.0f && !heroMovement.IsGrounded;
		}
	}
}