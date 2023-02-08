using Utils;
using UnityEngine;

namespace OOP {
	public class GrabHoldState : HeroMoveState {
		float distanceToGround;
		RaycastHit2D overheadRay;

		public GrabHoldState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			heroMovement.Busy = true;
			heroMovement.inputControl.MoveStarted += OnMove;
			heroMovement.movableRigidbody.gravityScale = 0;
			heroMovement.moveInput = 0;
			heroMovement.movableRigidbody.velocity = Vector2.zero;
			heroMovement.animations.Launch (AnimationType.GrabHold);

			overheadRay = Physics2D.Raycast (heroMovement.pointOverhead.transform.position + new Vector3 (0.2f, 0, 0) * heroMovement.transform.localScale.y, Vector2.down * heroMovement.transform.localScale.x, 0.2f, heroMovement.groundedMask);

			if (overheadRay.collider != null) {
				distanceToGround = heroMovement.pointOverhead.transform.position.y - overheadRay.point.y;
				heroMovement.transform.position = new Vector3 (heroMovement.transform.position.x, heroMovement.transform.position.y - distanceToGround + 0.01f, heroMovement.transform.position.z);
			}
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.Busy = false;
			heroMovement.inputControl.MoveStarted -= OnMove;
		}

		void OnMove ( float value ) {
			if (heroMovement.direction.CompareDirections (value)) {
				stateMachine.ChangeState (heroMovement.pullUpState);
			} else {
				if (ObstacleChecker.CheckFront (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.stairMask)) {
					heroMovement.transform.position = new Vector3 (heroMovement.transform.position.x, heroMovement.transform.position.y - 0.3f, heroMovement.transform.position.z);
					stateMachine.ChangeState (heroMovement.grabStairState);
				} else {
					heroMovement.direction.ReverseDirection ();
					stateMachine.ChangeState (heroMovement.fallState);
				}
			}
		}
	}
}
