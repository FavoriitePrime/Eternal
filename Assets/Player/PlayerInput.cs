using UnityEngine;

public class PlayerInput : MonoBehaviour , IPlayerInput
{
    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }
    public float GetVeritcalInput()
    {
        return Input.GetAxis("Vertical");
    }
    public Vector3 GetMouseInput()
    {
        return new Vector3(0, Input.GetAxis("Mouse X"), 0);
    }
    public int GetJumpInput(bool groundCheck)
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

}
