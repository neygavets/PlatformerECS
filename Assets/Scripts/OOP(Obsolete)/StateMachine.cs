using UnityEngine;

public class StateMachine {
	public State CurrentState { get; private set; }

	public void Initialize ( State startingState ) {
		CurrentState = startingState;
		startingState.Enter ();
	}

	public void ChangeState ( State newState ) {
		CurrentState.Exit ();
		Debug.Log ("Change State: " + CurrentState.GetType().Name + " to " + newState.GetType ().Name);
		CurrentState = newState;
		newState.Enter ();
	}
}
