using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FP
{
	// Todo separate input from movement fully...
	public class FPMove
	{
		private CharacterController characterController;
		private Transform playerTransform;

		private float movementSpeed = 10f;
        
		private InputAction moveInput;

		private Vector3 move;
        
		public FPMove(InputAction moveInput, CharacterController characterController ,Transform playerTransform)
		{
			this.moveInput = moveInput;
			this.characterController = characterController;
			this.playerTransform = playerTransform;
	        
			moveInput.performed += MoveInputOnPerformed;
			moveInput.canceled += MoveInputOnCanceled;
		}

		public void Update()
		{
			characterController.Move(move * movementSpeed * Time.deltaTime);
		}
        
		private void MoveInputOnPerformed(InputAction.CallbackContext ctx)
		{
			Vector2 moveRaw = ctx.ReadValue<Vector2>();
			move = playerTransform.right * moveRaw.x + playerTransform.forward * moveRaw.y;
		}
		
		private void MoveInputOnCanceled(InputAction.CallbackContext ctx)
		{
			move = Vector3.zero;
		}
	}
}
