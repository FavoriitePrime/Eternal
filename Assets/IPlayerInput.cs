using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    Vector2 MoveDirection { get; }
    Vector2 Rotation { get; }
    bool Jumped { get; }
}
