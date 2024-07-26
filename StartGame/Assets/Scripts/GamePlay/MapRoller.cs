using System;
using UnityEngine;

public class MapRoller : MonoBehaviour
{
    private Vector2 _rollInput;

    [SerializeField] private Transform ball;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float returnSpeed;

    private Rigidbody _rb;

    private void Awake()
    {
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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), returnSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, returnSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        transform.RotateAround(ball.transform.position, Vector3.right, _rollInput.y * rotationSpeed * Time.fixedDeltaTime);
        transform.RotateAround(ball.transform.position, Vector3.forward, _rollInput.x * rotationSpeed * Time.fixedDeltaTime);
    }
}
