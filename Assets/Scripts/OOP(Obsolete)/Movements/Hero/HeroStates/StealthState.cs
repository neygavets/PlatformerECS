namespace OOP {
	public class StealthState : FreeMovingState {
		public StealthState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine, heroMovement) {
		}

		public override void Enter () {
			base.Enter ();
			currentMoveAcceleration = heroMovement.settings.MoveAcceleration / 2;
			currentMaxMoveSpeed = heroMovement.settings.MaxMoveSpeed / 2;
			heroMovement.animations.Launch (AnimationType.Stealth, true);
			heroMovement.inputControl.Stealth += StealthOff;
		}

		public override void Exit () {
			base.Exit ();
			heroMovement.inputControl.Stealth -= StealthOff;
			heroMovement.animations.Launch (AnimationType.Stealth, false);
		}

		private void StealthOff () {
			stateMachine.ChangeState (heroMovement.standingState);
		}
	}
}
