using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GroundCheck))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerInput _input;
    private GroundCheck _groundCheck;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _input = GetComponent<PlayerInput>();
        _groundCheck = GetComponent<GroundCheck>(); 
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _playerMovement.Move(_rigidbody, _input.GetMoveDirection(_groundCheck.CheckOnGround()), _groundCheck);
        _playerMovement.Rotate(_rigidbody, _input.GetMouseInput());
    }
    private void FixedUpdate()
    {
        _playerMovement.Gravity(_rigidbody, _groundCheck.CheckOnGround());
    }
}
