using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _direction;

    private void Awake()
    {
        if (_rotationSpeed <= 0f)
            _rotationSpeed = 1f;
        if (_direction)
            _rotationSpeed = -_rotationSpeed;
    }

    void FixedUpdate()
    {
        this.transform.Rotate(0, 0f, _rotationSpeed);
    }
}
