using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallGravityScale;
    [Tooltip("GroundCheck")]
    [SerializeField] private Vector3 _size;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private LayerMask _layerMask;


    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
        Gravity();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            _rigidbody.AddForce(transform.up * _jumpForce,ForceMode.Acceleration);
        }
        else
        {
            return;
        }
    }
    private void Rotate()
    {
        transform.rotation *= Quaternion.Euler(GetMouseInput());
    }
    private void Move()
    {
        var direction = GetMoveDirection();
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction;
    }
    private void Gravity()
    {
        if(_rigidbody.velocity.y < 0 && !GroundCheck())
        {
            Debug.Log("Falling");
            _rigidbody.AddForce(-transform.up * _fallGravityScale, ForceMode.Impulse);
        }
        else
        {
            return;
        }
    }

    private bool GroundCheck()
    {
        if (Physics.OverlapBox(transform.position + _offset, _size, transform.rotation, _layerMask).Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Vector3 GetMoveDirection()
    {
        return (GetVeritcalInput() + GetHorizontalInput()) * _speed;
    }
    private Vector3 GetHorizontalInput()
    {
        return transform.right * Input.GetAxis("Horizontal");
    }
    private Vector3 GetVeritcalInput()
    {
        return transform.forward * Input.GetAxis("Vertical");
    }
    private Vector3 GetMouseInput()
    {
        return new Vector3(0, Input.GetAxis("Mouse X"), 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, GetHorizontalInput() + GetVeritcalInput() + transform.position);
        Gizmos.DrawWireCube(transform.position + _offset, _size);

    }
}
