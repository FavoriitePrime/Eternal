using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveabel 
{
    void Jump(Rigidbody rigidbody, Transform transform, float jumpForce, bool groundCheck);
    private void Rotate(Transform transform, Vector3 mouseInput)
    {
        transform.rotation *= Quaternion.Euler(mouseInput);
    }
    void Move(Rigidbody rigidbody, Vector3 moveDirection);
   
}
