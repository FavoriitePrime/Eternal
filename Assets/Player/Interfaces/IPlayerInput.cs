using UnityEngine;

public interface IPlayerInput
{

    Vector2 GetInput();

    Vector3 GetMouseInput();

    float GetJumpInput();
    
}
