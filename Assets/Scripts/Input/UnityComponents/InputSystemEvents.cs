using Common;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input {
	[RequireComponent (typeof (PlayerInput))]
	public class InputSystemEvents : MonoEvent {
		void Start () {
			PlayerInput playerInput = GetComponent<PlayerInput> ();
			InputAction moveAction = playerInput.currentActionMap.FindAction ("Move");
			moveAction.performed += ( InputAction.CallbackContext value ) => entity.Get<MovePerformedInputEvent> () = new MovePerformedInputEvent { Value = value.ReadValue<float> () };
			moveAction.canceled += ( InputAction.CallbackContext value ) => entity.Get<MoveCanceledInputEvent> () = new MoveCanceledInputEvent { Value = value.ReadValue<float> () };
			moveAction.started += ( InputAction.CallbackContext value ) => entity.Get<MoveStartedInputEvent> () = new MoveStartedInputEvent { Value = value.ReadValue<float> () };
			InputAction jumpAction = playerInput.currentActionMap.FindAction ("Jump");
			jumpAction.performed += ( InputAction.CallbackContext value ) => entity.Get<JumpInputEvent> ();
			InputAction duckAction = playerInput.currentActionMap.FindAction ("Duck");
			duckAction.performed += ( InputAction.CallbackContext value ) => entity.Get<DuckInputEvent> ();
			InputAction dashAction = playerInput.currentActionMap.FindAction ("Dash");
			dashAction.performed += ( InputAction.CallbackContext value ) => entity.Get<DashInputEvent> ();
		}
	}
}