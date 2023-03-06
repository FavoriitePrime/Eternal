using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof (PlayerInput))]

public class Player : MonoBehaviour
{
    private PlayerController _playerMovement;
    private PlayerInput _input;

    private Vector3 _moveDirection;
    private Vector3 _mouseRotation;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerController>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _mouseRotation = _input.GetMouseInput();
        _moveDirection = GetMoveDirection();
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_moveDirection);
        _playerMovement.Rotate(_mouseRotation);
        _playerMovement.Gravity();
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 direction = _input.GetInput().y * transform.forward + _input.GetInput().x * transform.right;
        direction.y = _input.GetJumpInput();
        return direction;
    }
}
