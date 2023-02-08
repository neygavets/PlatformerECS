namespace OOP {
	public class HeroMoveState : State {
		protected HeroMovement heroMovement;

		public HeroMoveState ( StateMachine stateMachine, HeroMovement heroMovement ) : base (stateMachine) {
			this.heroMovement = heroMovement;
		}
	}
}