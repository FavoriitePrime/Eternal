using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof (PlayerInput))]

public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerInput _input;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _playerMovement.Move(GetMoveDirection());
        _playerMovement.Rotate(_input.GetMouseInput());
    }
    private void FixedUpdate()
    {
        _playerMovement.Gravity();
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 direction = _input.GetInput().y * transform.forward + _input.GetInput().x * transform.right;
        direction.y = _input.GetJumpInput();
        return direction;
    }
}
