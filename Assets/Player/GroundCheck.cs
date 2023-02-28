using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("GroundCheck")]
    [SerializeField] private Vector3 _size;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private LayerMask _layerMask;

    public bool CheckOnGround()
    {
        if (Physics.OverlapBox(transform.position + _offset, _size, transform.rotation, _layerMask).Length != 0)
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
        Gizmos.DrawWireCube(transform.position + _offset, _size);

    }
}
