using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public bool CanMove { get; private set; }

    [SerializeField] private float rotationSpeed;

    private CharacterController _characterController;
    private Vector2 _moveVector;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        _moveVector = context.ReadValue<Vector2>();
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        _playerAttack.ApplyDamage(5);
    }

    private void Update()
    {
        if (!CanMove) return;

        var moveDirection = new Vector3(_moveVector.x, 0, _moveVector.y);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            var toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        _characterController.Move(moveDirection * (MoveSpeed * Time.deltaTime));
    }

    public void SetCanMove(bool value)
    {
        CanMove = value;
    }

    public void SetMoveSpeed(float speed)
    {
        MoveSpeed = speed;
    }
}