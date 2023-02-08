namespace OOP {
	public class FallState : FlightState {
		private bool isFalling;

		public FallState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			isFalling = true;
			heroMovement.animations.Launch (AnimationType.Fall);
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.animations.Launch (AnimationType.Landing);
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();

			// Приземление
			if (isFalling && heroMovement.IsGrounded) {
				stateMachine.ChangeState (heroMovement.standingState);
			}
		}
	}
}