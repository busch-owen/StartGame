using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    [SerializeField] private Vector3 followOffset;
    [SerializeField] private float followDamping;

    private Rigidbody _ballRB;

    private void Start()
    {
        _ballRB = followTarget?.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        transform.LookAt(followTarget);
        var followPos = new Vector3(followTarget.position.x + followOffset.x, followOffset.y, followTarget.transform.position.z + followOffset.z);
        transform.position = Vector3.Lerp(transform.position, followPos, followDamping * Time.deltaTime);
    }
}