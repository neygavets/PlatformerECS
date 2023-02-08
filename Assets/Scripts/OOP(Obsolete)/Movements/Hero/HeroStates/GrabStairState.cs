using Utils;
using UnityEngine;

namespace OOP {
	public class GrabStairState : VerticalMovingState {
		RaycastHit2D toStairRay;
		float distanceToStair;

		public GrabStairState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			heroMovement.Busy = true;
			heroMovement.inputControl.Jump += Jump;

			toStairRay = Physics2D.Raycast (heroMovement.pointGrab.transform.position, Vector2.right * heroMovement.transform.localScale.x, 0.2f, heroMovement.stairMask);

			if (toStairRay.collider != null) {
				distanceToStair = (Mathf.Abs (heroMovement.pointGrab.transform.position.x - toStairRay.point.x) + 0.01f) * heroMovement.transform.localScale.x;
				heroMovement.transform.position = new Vector3 (heroMovement.transform.position.x + distanceToStair, heroMovement.transform.position.y, heroMovement.transform.position.z);
			}

			heroMovement.animations.Launch (AnimationType.GrabStair, true);
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.Busy = false;
			heroMovement.inputControl.Jump -= Jump;
			heroMovement.animations.Launch (AnimationType.GrabStair, false);
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
			if (ObstacleChecker.CheckLedge (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.pointOverhead.transform.position, heroMovement.stairMask))
				stateMachine.ChangeState (heroMovement.grabHoldState);
			if (!ObstacleChecker.CheckFront (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.stairMask))
				stateMachine.ChangeState (heroMovement.standingState);
		}

		private void Jump () {
			heroMovement.direction.ReverseDirection ();
			stateMachine.ChangeState (heroMovement.jumpState);
		}
	}
}
