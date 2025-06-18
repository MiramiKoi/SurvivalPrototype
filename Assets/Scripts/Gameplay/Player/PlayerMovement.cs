using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        public void Move(Vector2 input)
        {
            var moveDirection = new Vector3(input.x, 0, input.y);
            
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}