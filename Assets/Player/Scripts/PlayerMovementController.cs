using UnityEngine;

public class PlayerMovementController 
{
    private Transform _orientation;
    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private float _yVelocity;
    private Vector3 _moveVelocity;

    public PlayerMovementController(ref CharacterController characterController, ref Transform playerOrientation)
    {
        _orientation = playerOrientation;
        _characterController = characterController;
    }

    public void WallRun(Vector2 input, ref float speed, ref Vector3 wallNormal)
    {
        _moveVelocity = Vector3.Cross(wallNormal, Vector3.up);
        if (Vector3.Dot(_moveVelocity, _orientation.forward) < 0)
        {
            _moveVelocity = -_moveVelocity;
        }
        if (input.y > (_moveVelocity.z - 10f) & input.y < (_moveVelocity.z + 10f))
        {
            _moveVelocity *= speed;
            _moveVelocity.y += _yVelocity;
            _moveDirection = _moveVelocity;
        }
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
    public void EnterWallRun()
    {
        _yVelocity = 0;
    }

    public void Move(Vector2 input, ref float speed)
    {
        input *= speed;
        _moveVelocity = _orientation.TransformDirection(input.x, _yVelocity, input.y);
        _moveDirection = _moveVelocity;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    public void Jump(ref float jumpForce, ref bool isWallRunning)
    {
        if (_characterController.isGrounded || isWallRunning)
        {
            _yVelocity += jumpForce;
        }
    }

    public void Gravity(ref float gravity, ref float gravityMultiplyer)
    {
        if (!_characterController.isGrounded)
        {
            _yVelocity += (gravity * gravityMultiplyer) * Time.deltaTime;
        }
        else
        {
            _yVelocity = gravity * Time.deltaTime;
        }
    }
}
