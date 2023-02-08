using UnityEngine;

namespace OOP {
	public class DashState : HeroMoveState {
		protected Vector2 velocity;
		protected float currentMaxDashSpeed;
		private float timeCounter, timeout;
		private bool dashEnd;

		public DashState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			currentMaxDashSpeed = heroMovement.settings.MaxDashSpeed;

			timeout = 0.5f;
			timeCounter = 0.0f;
			dashEnd = false;

			heroMovement.movableRigidbody.velocity = Vector2.zero;
			heroMovement.movableRigidbody.AddForce (Vector2.right * heroMovement.transform.localScale.x * heroMovement.settings.DashAcceleration, ForceMode2D.Impulse);
			heroMovement.animations.Launch (AnimationType.Dash);
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.movableRigidbody.velocity = Vector2.zero;
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
			if (!dashEnd) {
				timeCounter += Time.deltaTime;
				if (timeCounter > timeout) {
					dashEnd = true;
					stateMachine.ChangeState (heroMovement.standingState);
				}
			}
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
			// Берем текущую скорость тела
			velocity = heroMovement.movableRigidbody.velocity;
			// Ограничиваем горизонтальную скорость
			velocity.x = Mathf.Clamp (velocity.x, -currentMaxDashSpeed, currentMaxDashSpeed);
			// Не даем возможности двигаться по вертикали
			velocity.y = 0.0f;
			// Возвращаем скорость
			heroMovement.movableRigidbody.velocity = velocity;
		}

	}
}