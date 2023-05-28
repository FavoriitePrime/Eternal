using UnityEngine;

public interface IMovable 
{
    public void Move(Vector2 input, ref float speed);
    public void Jump(ref float jumpForce);
}