using UnityEngine;

public interface IMovable 
{
    void Rotate(Vector2 input);
    void Move(Vector3 direction);
}