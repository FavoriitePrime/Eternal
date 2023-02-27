using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour , IPlayerInput
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
        Move(_rigidbody,GetMoveDirection());
        Rotate(transform, GetMouseInput());
        Jump(_rigidbody, transform, _jumpForce, GroundCheck());
        Gravity();
    }

    private void Jump(Rigidbody rigidbody, Transform transform, float jumpForce, bool groundCheck)
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck)
        {
            rigidbody.AddForce(transform.up * jumpForce,ForceMode.Acceleration);
        }
        else
        {
            return;
        }
    }
    private void Rotate(Transform transform, Vector3 mouseInput)
    {
        transform.rotation *= Quaternion.Euler(mouseInput);
    }
    private void Move(Rigidbody rigidbody, Vector3 moveDirection)
    {
        var direction = moveDirection.normalized;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;
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

    public Vector3 GetMoveDirection()
    {
        return (GetVeritcalInput(transform) + GetHorizontalInput(transform)) * _speed;
    }
    public Vector3 GetHorizontalInput(Transform transform)
    {
        return transform.right * Input.GetAxis("Horizontal");
    }
    public Vector3 GetVeritcalInput(Transform transform)
    {
        return transform.forward * Input.GetAxis("Vertical");
    }
    public Vector3 GetMouseInput()
    {
        return new Vector3(0, Input.GetAxis("Mouse X"), 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, GetHorizontalInput(transform) + GetVeritcalInput(transform) + transform.position);
        Gizmos.DrawWireCube(transform.position + _offset, _size);

    }
}
