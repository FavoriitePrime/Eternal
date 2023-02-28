using UnityEngine;

public class PlayerInput : MonoBehaviour , IPlayerInput
{
    public Vector3 GetHorizontalInput(Transform transform)
    {
        return transform.right * Input.GetAxis("Horizontal");
    }
    public Vector3 GetVeritcalInput(Transform transform)
    {
        return transform.forward * Input.GetAxis("Vertical");
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

    public Vector3 GetMoveDirection(bool groundCheck)
    {
        Vector3 direction = (GetVeritcalInput(transform) + GetHorizontalInput(transform));
        direction.y = GetJumpInput(groundCheck);
        return direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, GetHorizontalInput(transform) + GetVeritcalInput(transform) + transform.position);
    }
}
