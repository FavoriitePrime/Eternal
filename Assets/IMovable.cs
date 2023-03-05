using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable 
{
    void Jump();
    void Rotate(Vector3 rotation);
    void Move(Vector3 direction);
}
