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

    public bool IsOnGround()
    {
        if (Physics.Raycast(transform.position + _offset, -transform.up * _maxDistance,out hit, _maxDistance, _layerMask))
        {
            Debug.Log(hit.distance);
            Debug.Log(hit.distance < _jumpMinHeight);
            if (hit.distance < _jumpMinHeight)
            {
            Debug.Log("OnGround");
            return true;
            }
            else
            {
                Debug.Log("not Ground");
                return false;
            }
        }
        else
        {
            Debug.Log("not Ground");
            return false;
        }
    }
    public bool IsMaxJumpHeight()
    { 
        if(hit.distance > _jumpMaxHeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Ray ray = new Ray(transform.position + _offset, -transform.up * _maxDistance);
        Gizmos.DrawRay(ray);
    }
}
