using UnityEngine;

public class PlayerController : MonoBehaviour , IMovable
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _defualtGravityScale;
    [SerializeField] private float _fallGravityScale;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Rotate(Vector3 rotation)
    {
        if (rotation.sqrMagnitude > 1)
            rotation.Normalize();

        _rigidbody.rotation *= Quaternion.Euler(rotation);
    }

    public void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        _rigidbody.velocity = direction * _speed;
    }

    public void Jump()
    {
        var velocity = _rigidbody.velocity;
        velocity.y = _jumpForce;
        _rigidbody.velocity = velocity;
    }
  
    public void Gravity(bool groundCheck, bool isMaxGroundHeight)
    {
        if(!groundCheck && isMaxGroundHeight)
        {
            Debug.Log("Physics");
            _rigidbody.AddForce(-transform.up * _fallGravityScale, ForceMode.Impulse);
        }
        else
        {
            _rigidbody.AddForce(-transform.up * _defualtGravityScale, ForceMode.Impulse);
        }
    }

}
