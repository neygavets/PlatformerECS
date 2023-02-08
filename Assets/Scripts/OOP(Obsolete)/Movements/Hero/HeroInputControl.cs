using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OOP {
	public class HeroInputControl : MonoBehaviour {
		public event Action<float> MoveStarted;
		public event Action<float> MovePerformed;
		public event Action<float> MoveCanceled;
		public event Action Jump;
		public event Action Stealth;
		public event Action Duck;
		public event Action Dash;

		void Start () {
			PlayerInput playerInput = GetComponent<PlayerInput> ();
			if (playerInput != null) {
				InputAction moveAction = playerInput.currentActionMap.FindAction ("Move");
				moveAction.performed += ( InputAction.CallbackContext value ) => MovePerformed?.Invoke (value.ReadValue<float> ());
				moveAction.canceled += ( InputAction.CallbackContext value ) => MoveCanceled?.Invoke (value.ReadValue<float> ());
				moveAction.started += ( InputAction.CallbackContext value ) => MoveStarted?.Invoke (value.ReadValue<float> ());

				InputAction jumpAction = playerInput.currentActionMap.FindAction ("Jump");
				jumpAction.performed += ( InputAction.CallbackContext value ) => Jump?.Invoke ();

				//InputAction stealthAction = playerInput.currentActionMap.FindAction ("Stealth");
				//stealthAction.performed += ( InputAction.CallbackContext value ) => Stealth?.Invoke ();

				InputAction duckAction = playerInput.currentActionMap.FindAction ("Duck");
				duckAction.performed += ( InputAction.CallbackContext value ) => Duck?.Invoke ();

				InputAction dashAction = playerInput.currentActionMap.FindAction ("Dash");
				dashAction.performed += ( InputAction.CallbackContext value ) => Dash?.Invoke ();
			}
		}

		/*	
			// Реализация Input System с Send Messages/Broadcast Messages
			void OnMove ( InputValue value ) {
				MovePerformed?.Invoke (value.Get<float> ());
			}

			// Реализация Input System с Unity Events
			public void OnMove ( InputAction.CallbackContext context ) {
				if(context.started)
					MoveStarted?.Invoke (context.ReadValue<float> ());

			}
		*/
	}
}
