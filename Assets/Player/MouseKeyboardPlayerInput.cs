using UnityEngine;

public class MouseKeyboardPlayerInput : MonoBehaviour , IPlayerInput
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    public Vector2 MoveDirection => new(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));
    public Vector2 Rotation => new (Input.GetAxis(MOUSE_X), Input.GetAxis(MOUSE_Y));
    public bool Jumped => Input.GetKeyDown(KeyCode.Space);


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, (transform.forward * MoveDirection.y + transform.right * MoveDirection.x).normalized + transform.position);
    }
}
