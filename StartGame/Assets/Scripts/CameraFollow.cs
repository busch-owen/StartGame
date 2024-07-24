using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    [SerializeField] private Vector3 followOffset;

    private Rigidbody _ballRB;

    private void Start()
    {
        _ballRB = followTarget?.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(followTarget.position.x + followOffset.x, followOffset.y, followTarget.transform.position.z + followOffset.z);
    }
}
