using UnityEngine;

public class PlayerInput : MonoBehaviour , IPlayerInput
{
    public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    public int GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    public Vector3 GetMouseInput()
    {
        return new Vector3(0, Input.GetAxis("Mouse X"), 0);
    }
}
