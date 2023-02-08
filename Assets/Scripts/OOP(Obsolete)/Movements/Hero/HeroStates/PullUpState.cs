using UnityEngine;

namespace OOP {
	public class PullUpState : HeroMoveState {
		private float timeCounter;
		private float timeout;
		private bool playAnimation;

		public PullUpState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			heroMovement.animations.Launch (AnimationType.PullUp, true);
			//timeout = heroMovement.animations.GetCurrentAnimationTime ();
			//Debug.Log ("Animation time: " + timeout);
			timeout = 1.5f;
			timeCounter = 0.0f;
			playAnimation = true;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.movableRigidbody.velocity = Vector2.zero;
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
			if (playAnimation) {
				timeCounter += Time.deltaTime;
				if (timeCounter > timeout) {
					playAnimation = false;
					PullUpEnd ();
				}
			}
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
		}

		void PullUpEnd () {

			heroMovement.transform.position = Physics2D.Raycast (heroMovement.pointClimbLedge.transform.position, Vector2.down, 0.5f, heroMovement.groundedMask).point;

			heroMovement.animations.Launch (AnimationType.PullUp, false);
			stateMachine.ChangeState (heroMovement.standingState);
		}
	}
}
