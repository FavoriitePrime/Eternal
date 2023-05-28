using UnityEngine;

public class PlayerCameraController
{
    private Transform _cameraTarget;
    private Transform _orientation;
    private Vector2 _mouseRotation;

    public PlayerCameraController(ref Transform orientation, ref Transform cameraTarget)
    {
        _cameraTarget = cameraTarget;
        _orientation = orientation;
    }

    public void Rotate(Vector2 mouseDelta, ref float Sensivity, ref Vector2 Clamp)
    {
        _mouseRotation.x -= mouseDelta.y;
        _mouseRotation.x = Mathf.Clamp(_mouseRotation.x, Clamp.x , Clamp.y);
        _mouseRotation.y += mouseDelta.x;
        _cameraTarget.transform.rotation = Quaternion.Euler(_mouseRotation.x * Sensivity, _mouseRotation.y * Sensivity, 0 );
        _orientation.transform.rotation = Quaternion.Euler(0, _mouseRotation.y * Sensivity, 0);
    }

}
