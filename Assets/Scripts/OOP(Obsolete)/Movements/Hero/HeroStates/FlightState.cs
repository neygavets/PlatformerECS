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
			// ���������, ���� �� ����� � �����, �� ������� ����� ����������
			if (ObstacleChecker.CheckLedge (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.pointOverhead.transform.position, heroMovement.wallMask))
				stateMachine.ChangeState (heroMovement.grabHoldState);
			// ���������, ���� �� ����� ���� ��������
			if (ObstacleChecker.CheckFront (heroMovement.transform, heroMovement.pointGrab.transform.position, heroMovement.stairMask))
				stateMachine.ChangeState (heroMovement.grabStairState);
		}

		private void OnDash () {
			stateMachine.ChangeState (heroMovement.dashState);
		}
	}
}
