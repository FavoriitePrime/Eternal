using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _defualtGravityScale;
    [SerializeField] private float _fallGravityScale;

    public void Rotate(Rigidbody rigidbody, Vector3 mouseInput)
    {
        rigidbody.rotation *= Quaternion.Euler(mouseInput);
    }
    public void Move(Rigidbody rigidbody, Vector3 moveDirection)
    {
        Vector3 direction = new Vector3();
        moveDirection.Normalize();
        direction.x = moveDirection.x * _speed;
        direction.y = rigidbody.velocity.y + (moveDirection.y * _jumpForce);
        direction.z = moveDirection.z * _speed;

        rigidbody.velocity = direction;
    }
  

    public void Gravity(Rigidbody rigidbody, bool groundCheck, bool maxGroundHeight)
    {
        if(!groundCheck && maxGroundHeight)
        {
            Debug.Log("Physics");
            rigidbody.AddForce(-transform.up * _fallGravityScale, ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddForce(-transform.up * _defualtGravityScale, ForceMode.Impulse);
        }
    }

}
