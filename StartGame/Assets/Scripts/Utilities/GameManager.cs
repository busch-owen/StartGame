using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelStatusHandler _levelStatusHandler;

    [SerializeField] private Vector3 defaultGravity;

    private void Awake()
    {
        _levelStatusHandler = FindObjectOfType<LevelStatusHandler>();
        Physics.gravity = defaultGravity;
    }

    private void Start()
    {
        StartSequence();
    }

    private void StartSequence()
    {
        StartCoroutine(_levelStatusHandler.CountdownSequence());
    }
}
