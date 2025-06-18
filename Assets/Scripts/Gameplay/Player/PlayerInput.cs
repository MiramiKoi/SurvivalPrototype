using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 _inputVector;
        
        public void MoveInput(InputAction.CallbackContext context)
        {
            _inputVector = context.ReadValue<Vector2>();
        }

        public Vector2 GetMovementInput()
        {
            return _inputVector.normalized;
        }
    }
}