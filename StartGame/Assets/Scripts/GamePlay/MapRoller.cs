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
        _rollInput = -input;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(ball.transform.localPosition, Vector3.right, _rollInput.y * rollerStats.RotationSpeed * Time.fixedDeltaTime);
        transform.RotateAround(ball.transform.localPosition, Vector3.forward, _rollInput.x * rollerStats.RotationSpeed * Time.fixedDeltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0 , 0), rollerStats.ReturnSpeed * Time.fixedDeltaTime);
        //transform.position = Vector3.Lerp(transform.position, Vector3.zero, rollerStats.ReturnSpeed * Time.fixedDeltaTime);
    }
}
