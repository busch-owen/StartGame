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
        transform.RotateAround(ball.transform.position, Vector3.right, _rollInput.y * rotationSpeed * Time.fixedDeltaTime);
        transform.RotateAround(ball.transform.position, Vector3.forward, _rollInput.x * rotationSpeed * Time.fixedDeltaTime);
        _rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), returnSpeed * Time.deltaTime);
        _rb.position = Vector3.Lerp(transform.position, Vector3.zero, returnSpeed * Time.deltaTime);
    }
}
