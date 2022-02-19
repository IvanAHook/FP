using UnityEngine;
using UnityEngine.InputSystem;

namespace FP
{
	public class FPMouseLook
	{
		private Transform playerTransform;
		private Transform cameraTransform;
		
		private InputAction lookInput;

		private float lookSensitivity = 50f;
		private float xRotation;

		public FPMouseLook(InputAction lookInput, Transform playerTransform, Transform cameraTransform)
		{
			this.lookInput = lookInput;
			this.playerTransform = playerTransform;
			this.cameraTransform = cameraTransform;
			
			Cursor.lockState = CursorLockMode.Locked;

			lookInput.performed += LookOnperformed;
		}
		
		private void LookOnperformed(InputAction.CallbackContext ctx)
		{
			Vector2 rawMousePosition = ctx.ReadValue<Vector2>(); 
			Vector2 mousePosition = rawMousePosition * lookSensitivity * Time.deltaTime;

			xRotation -= mousePosition.y;
			xRotation = Mathf.Clamp(xRotation, -90, 90);
        	
			cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
			playerTransform.Rotate(Vector3.up * mousePosition.x);
		}
		
	}
}
