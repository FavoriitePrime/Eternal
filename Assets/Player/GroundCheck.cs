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
        RayCastUpdate();  
        return (transform.position.y + _offset.y - hit.point.y < _jumpMinHeight);

    }

    public bool CheckMaxJumpHeight()
    {
        RayCastUpdate();
        return (transform.position.y + _offset.y - hit.point.y > _jumpMaxHeight);
    }

    private void RayCastUpdate()
    {
        Physics.Raycast(transform.position + _offset, -transform.up * _maxDistance, out hit, _maxDistance, _layerMask);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Ray ray = new Ray(transform.position + _offset, -transform.up * _maxDistance);
        Gizmos.DrawRay(ray);
    }
#endif
}
