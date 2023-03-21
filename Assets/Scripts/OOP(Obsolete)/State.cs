namespace OOP {
	public class State {
		protected StateMachine stateMachine;

		protected State ( StateMachine stateMachine ) {
			this.stateMachine = stateMachine;
		}

		/// <summary>
		/// ����������� ��� ����� � ���������.
		/// </summary>
		public virtual void Enter () { }

		/// <summary>
		/// ���������� ������� ������.
		/// </summary>
		public virtual void LogicUpdate () { }

		/// <summary>
		/// ������� ������.
		/// </summary>
		public virtual void PhysicsUpdate () { }

		/// <summary>
		/// ����������� ��� ������ �� ���������.
		/// </summary>
		public virtual void Exit () { }
	}
}

