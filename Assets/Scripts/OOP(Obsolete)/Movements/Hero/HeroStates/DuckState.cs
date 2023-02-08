using UnityEngine;

namespace OOP {
	public class DuckState : FreeMovingState {
		private Vector2 duckColliderSize;
		private Vector2 duckColliderOffset;
		private Vector2 headPoint;
		private float headRadius = 0.18f;

		public DuckState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
			duckColliderSize = new Vector2 (heroMovement.normalBodySize.x, heroMovement.normalBodySize.y / 2f);
			duckColliderOffset = new Vector2 (heroMovement.normalBodyOffset.x, heroMovement.normalBodyOffset.y + (duckColliderSize.y - heroMovement.normalBodySize.y) / 2f);

		}

		public override void Enter () {
			base.Enter ();
			heroMovement.Busy = true;

			heroMovement.bodyCollider.size = duckColliderSize;
			heroMovement.bodyCollider.offset = duckColliderOffset;


			heroMovement.animations.Launch (AnimationType.Duck, true);
			heroMovement.inputControl.Duck += StandUp;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.Busy = false;

			heroMovement.bodyCollider.size = heroMovement.normalBodySize;
			heroMovement.bodyCollider.offset = heroMovement.normalBodyOffset;

			heroMovement.animations.Launch (AnimationType.Duck, false);
			heroMovement.inputControl.Duck -= StandUp;
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
		}

		private void StandUp () {
			headPoint = new Vector2 (heroMovement.transform.position.x, heroMovement.transform.position.y + heroMovement.normalBodySize.y - 0.05f);
			if (!Physics2D.OverlapCircle (headPoint, headRadius, heroMovement.groundedMask))
				//if (!heroMovement.overHeadCollider.IsTouchingLayers (heroMovement.groundMask))
				stateMachine.ChangeState (heroMovement.standingState);
		}
	}
}
