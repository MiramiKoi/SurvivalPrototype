using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed;
    
        [SerializeField] private Vector3 baseOffset;
        [SerializeField] private float offsetDistance = 2f;
    
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _lastPlayerPosition;

        private void Start()
        {
            _lastPlayerPosition = target.position; // Запоминаем стартовую позицию игрока
        }
    
        private void Update()
        {
            var playerMovement = target.position - _lastPlayerPosition;
            _lastPlayerPosition = target.position;
        
            var movementOffset = new Vector3(playerMovement.x, 0, playerMovement.z).normalized * offsetDistance;
        
            var targetPosition = target.position + baseOffset + movementOffset;
        
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothSpeed * Time.deltaTime);
        }
    }
}
