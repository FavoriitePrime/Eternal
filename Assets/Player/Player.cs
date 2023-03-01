using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerMoveDirection))]
[RequireComponent(typeof (PlayerInput))]

public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerMoveDirection _direction;
    private PlayerInput _input;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _direction = GetComponent<PlayerMoveDirection>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _playerMovement.Move(_direction);
        _playerMovement.Rotate(_input);
    }
    private void FixedUpdate()
    {
        _playerMovement.Gravity();
    }
}
