using UnityEngine;

public interface IPlayerInput
{
    float GetHorizontalInput();

    float GetVeritcalInput();

    Vector3 GetMouseInput();

    int GetJumpInput(bool groundCheck);
    
}
