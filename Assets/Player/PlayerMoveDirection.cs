using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class PlayerMoveDirection : MonoBehaviour
{
    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    public Vector3 GetHorizontalDirection()
    {
        return transform.forward * _input.GetVeritcalInput();
    }
    public Vector3 GetVerticalDirection()
    {
        return transform.right * _input.GetHorizontalInput();
    }
    public Vector3 GetMoveDirection(bool groundCheck)
    {
        Vector3 direction = (GetVerticalDirection() + GetHorizontalDirection());
        direction.y = _input.GetJumpInput(groundCheck);
        return direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, GetHorizontalDirection() + 
            GetVerticalDirection() + transform.position);
    }
}
