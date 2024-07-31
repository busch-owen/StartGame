using UnityEngine;

public class MapRoller : MonoBehaviour
{
    private Vector2 _rollInput;

    private Vector3 _startPos;

    private Transform ball;

    [SerializeField] private MapRollerSO rollerStats;
    

    private void Awake()
    {
        _startPos = transform.position;
        ball = FindObjectOfType<Player>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GetInput(Vector2 input)
    {
        _rollInput = -input.normalized;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(ball.transform.position, Vector3.right, _rollInput.y * rollerStats.RotationSpeed * Time.fixedDeltaTime);
        transform.RotateAround(ball.transform.position, Vector3.forward, _rollInput.x * rollerStats.RotationSpeed * Time.fixedDeltaTime);
    }
}
