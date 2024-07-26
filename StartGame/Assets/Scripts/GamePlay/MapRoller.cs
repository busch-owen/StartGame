using UnityEngine;

public class MapRoller : MonoBehaviour
{
    private Vector2 _rollInput;

    private Transform ball;

    [SerializeField] private MapRollerSO rollerStats;

    private Rigidbody _rb;

    private void Awake()
    {
        ball = FindObjectOfType<Player>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _rb = GetComponent<Rigidbody>();
    }

    public void GetInput(Vector2 input)
    {
        _rollInput = -input;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rollerStats.ReturnSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, rollerStats.ReturnSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        transform.RotateAround(ball.transform.position, Vector3.right, _rollInput.y * rollerStats.RotationSpeed * Time.fixedDeltaTime);
        transform.RotateAround(ball.transform.position, Vector3.forward, _rollInput.x * rollerStats.RotationSpeed * Time.fixedDeltaTime);
    }
}
