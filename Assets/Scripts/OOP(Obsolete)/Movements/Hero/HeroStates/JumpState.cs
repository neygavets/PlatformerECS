using UnityEngine;

namespace OOP {
	public class JumpState : FlightState {
		private bool isJumping;
		private bool jumpInput;
		private bool doubleJumpReady;

		public JumpState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			jumpInput = true;
			isJumping = false;
			doubleJumpReady = false;
			heroMovement.inputControl.Jump += Jump;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.inputControl.Jump -= Jump;
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
			// ������
			if (jumpInput) {
				// ���������� ������� ���� ��� ������
				heroMovement.movableRigidbody.AddForce (new Vector2 (0, heroMovement.settings.JumpForce), ForceMode2D.Impulse);
				if (!heroMovement.IsGrounded) {
					// ������� ������ (� �������)
					doubleJumpReady = false;
					heroMovement.animations.Launch (AnimationType.DoubleJump);
				} else {
					// ������� ������
					doubleJumpReady = true;
					heroMovement.animations.Launch (AnimationType.Jump);
				}
				jumpInput = false;
				isJumping = true;
			}
		}

		private void Jump () {
			if (!isJumping || doubleJumpReady)
				jumpInput = true;
		}

	}
}
