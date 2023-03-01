using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GroundCheck))]

public class PlayerMovement : MonoBehaviour ,IMovabel
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _defualtGravityScale;
    [SerializeField] private float _fallGravityScale;

    private Rigidbody _rigidbody;
    private GroundCheck _groundCheck;

    private void Start()
    {
        _groundCheck = GetComponent<GroundCheck>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Rotate(Vector2 input)
    {
        _rigidbody.rotation *= Quaternion.Euler(input);
    }
    public void Move(Vector3 direction)
    {
        direction.Normalize();
        direction.x *= _speed;
        direction.z *= _speed;
        direction.y = Jump(direction.y);
        _rigidbody.velocity = direction;
    }

    public float Jump(float y)
    {
        if (_groundCheck.CheckOnGround())
        {
            return _rigidbody.velocity.y + (y * _jumpForce);
        }
        else
        {
            return _rigidbody.velocity.y;

        }

    }


    public void Gravity()
    {
        if(!_groundCheck.CheckOnGround() && _groundCheck.CheckMaxJumpHeight())
        {
            _rigidbody.AddForce(-transform.up * _fallGravityScale, ForceMode.Impulse);
        }
        else
        {
            _rigidbody.AddForce(-transform.up * _defualtGravityScale, ForceMode.Impulse);
        }
    }


}
