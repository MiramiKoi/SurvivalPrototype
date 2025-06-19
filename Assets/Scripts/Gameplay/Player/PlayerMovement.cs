using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;

        private Vector3 _currentVelocity;
        
        public void Move(Vector2 input)
        {
            var moveVector = new Vector3(input.x, 0, input.y);
            
            // Плавное ускорение/торможение персонажа
            var accel = input.magnitude > 0 ? acceleration : deceleration;
            _currentVelocity = Vector3.MoveTowards(_currentVelocity, moveVector, accel * Time.deltaTime);
            
            transform.Translate(_currentVelocity * (moveSpeed * Time.deltaTime), Space.World);

            // Поворот в сторону движения
            if (_currentVelocity.magnitude > 0.1f)
                transform.rotation = Quaternion.LookRotation(_currentVelocity);
        }
    }
}