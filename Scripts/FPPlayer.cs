using System;
using UnityEngine;

namespace FP
{
	public class FPPlayer : MonoBehaviour
	{
		[SerializeField] private CharacterController characterController;
		[SerializeField] private Transform cameraTransform;
		
		private FPPlayerActions fpPlayerActions;
		private FPPlayerActions.PlayerControlsActions controls;

		private FPMouseLook mouseLook;
		private FPMove movement;
		
		private void Awake()
		{
			Cursor.lockState = CursorLockMode.Locked;
			
			fpPlayerActions = new FPPlayerActions();
			controls = fpPlayerActions.PlayerControls;

			mouseLook = new FPMouseLook(controls.Look, transform, cameraTransform);
			movement = new FPMove(controls.Movement, characterController, transform);

			controls.Movement.performed += context => Debug.Log($"started moving: {context.ReadValue<Vector2>()}");
			controls.Movement.canceled += context => Debug.Log($"stopped moving: {context.ReadValue<Vector2>()}");
		}

		private void OnEnable()
		{
			controls.Enable();
		}
		private void OnDisable()
		{
			controls.Disable();
		}

		private void Update()
		{
			movement.Update();
		}

	}
}
