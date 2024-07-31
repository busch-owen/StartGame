using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public Rigidbody RB { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
}
