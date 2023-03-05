using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GroundCheck))]

public class PlayerController : MonoBehaviour ,IMovable
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
        direction.x *= _speed;
        direction.z *= _speed;
        direction.y = _rigidbody.velocity.y + (direction.y * _jumpForce);
        _rigidbody.velocity = direction;
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
