using Utils;

namespace OOP {
	public class FlightState : FreeMovingState {

		public FlightState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			heroMovement.inputControl.Dash += OnDash;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.inputControl.Dash -= OnDash;
		}

		public override void LogicUpdate () {
			base.LogicUpdate ();
		}

		public override void PhysicsUpdate () {
			base.PhysicsUpdate ();
			// ѕровер€ем, есть ли уступ у стены, за который можно ухватитьс€
			if (ObstacleChecker.CheckLedge (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.pointOverhead.transform.position, heroMovement.wallMask))
				stateMachine.ChangeState (heroMovement.grabHoldState);
			// ѕровер€ем, есть ли перед нами лестница
			if (ObstacleChecker.CheckFront (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.stairMask))
				stateMachine.ChangeState (heroMovement.grabStairState);
		}

		private void OnDash () {
			stateMachine.ChangeState (heroMovement.dashState);
		}
	}
}
