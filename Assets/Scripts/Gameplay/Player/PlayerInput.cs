using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 _inputVector;
        private bool _interact;
        
        public void MoveInput(InputAction.CallbackContext context)
        {
            _inputVector = context.ReadValue<Vector2>();
        }

        public void InteractInput(InputAction.CallbackContext context)
        {
            _interact = context.performed;
        }

        public bool GetInteractPressed()
        {
            var wasPressed = _interact;
            _interact = false;
            return wasPressed;
        }

        public Vector2 GetMovementInput()
        {
            return _inputVector.normalized;
        }
    }
}