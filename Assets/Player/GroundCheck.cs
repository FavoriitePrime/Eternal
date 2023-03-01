using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("GroundCheck")]
    [SerializeField] private float _maxDistance;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] public float _jumpMaxHeight;
    [SerializeField] public float _jumpMinHeight;

    private RaycastHit hit;

    public bool CheckOnGround()
    {
        if (Physics.Raycast(transform.position + _offset, -transform.up * _maxDistance,out hit, _maxDistance, _layerMask))
        {
            return (hit.distance < _jumpMinHeight);
        }
        else
        {
            return false;
        }
    }

    public bool CheckMaxJumpHeight()
    {
        return (hit.distance > _jumpMaxHeight);
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Ray ray = new Ray(transform.position + _offset, -transform.up * _maxDistance);
        Gizmos.DrawRay(ray);
    }
}
