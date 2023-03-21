namespace OOP {
	public class State {
		protected StateMachine stateMachine;

		protected State ( StateMachine stateMachine ) {
			this.stateMachine = stateMachine;
		}

		/// <summary>
		/// Выполняется при входе в состояние.
		/// </summary>
		public virtual void Enter () { }

		/// <summary>
		/// Выполнение игровой логики.
		/// </summary>
		public virtual void LogicUpdate () { }

		/// <summary>
		/// Рассчет физики.
		/// </summary>
		public virtual void PhysicsUpdate () { }

		/// <summary>
		/// Выполняется при выходе из состояния.
		/// </summary>
		public virtual void Exit () { }
	}
}

