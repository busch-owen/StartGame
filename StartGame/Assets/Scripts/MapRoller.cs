using System;
using UnityEngine;

public class MapRoller : MonoBehaviour
{
    private Vector2 _rollInput;

    [SerializeField] private Transform ball;

    [SerializeField] private Vector2 maxRotation;

    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GetInput(Vector2 input)
    {
        Debug.Log(input);
        _rollInput = new Vector2(-input.x * maxRotation.x, -input.y * maxRotation.y);
    }

    private void Update()
    {
        transform.RotateAround(ball.transform.position, Vector3.right, _rollInput.y * rotationSpeed * Time.deltaTime);
        transform.RotateAround(ball.transform.position, Vector3.forward, _rollInput.x * rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1f * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, 1f * Time.deltaTime);
    }
}
