namespace OOP {
	public class StandingState : FreeMovingState {
		public StandingState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			heroMovement.Busy = false;
			heroMovement.inputControl.Jump += Jump;
			heroMovement.inputControl.Stealth += OnStealth;
			heroMovement.inputControl.Duck += OnDuck;
			heroMovement.inputControl.Dash += OnDash;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.inputControl.Jump -= Jump;
			heroMovement.inputControl.Stealth -= OnStealth;
			heroMovement.inputControl.Duck -= OnDuck;
			heroMovement.inputControl.Dash -= OnDash;
		}

		private void Jump () {
			stateMachine.ChangeState (heroMovement.jumpState);
		}

		private void OnStealth () {
			stateMachine.ChangeState (heroMovement.stealthState);
		}

		private void OnDuck () {
			stateMachine.ChangeState (heroMovement.duckState);
		}

		private void OnDash () {
			stateMachine.ChangeState (heroMovement.dashState);
		}
	}
}