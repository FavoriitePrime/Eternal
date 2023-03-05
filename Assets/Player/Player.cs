using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GroundCheck))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    private PlayerController _playerMovement;
    private IPlayerInput _input;
    private GroundCheck _groundCheck;

    private Vector3 _moveDirection;
    private Vector3 _inputRotation;
    private bool _jumped;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerController>();
        _input = GetComponent<IPlayerInput>();
        _groundCheck = GetComponent<GroundCheck>(); 
    }

    private void Update()
    {
        var inputMoveDirection = _input.MoveDirection;
        _moveDirection = transform.forward * inputMoveDirection.y + transform.right * inputMoveDirection.x;
        _inputRotation = new Vector3(0f, _input.Rotation.x, 0f);
        _jumped = _input.Jumped;
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_moveDirection);
        _playerMovement.Rotate(_inputRotation);

        var isOnGround = _groundCheck.IsOnGround();
        var isMaxJumpHeight = _groundCheck.IsMaxJumpHeight();
        
        if (_jumped && isOnGround)
            _playerMovement.Jump();
        
        _playerMovement.Gravity(isOnGround, isMaxJumpHeight);
    }
}
