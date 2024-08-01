using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelStatusHandler _levelStatusHandler;

    [SerializeField] private Vector3 defaultGravity;

    [SerializeField] private int targetFrameRate = 300;
    [SerializeField] private int vSyncOn = 0;

    private void Awake()
    {
        QualitySettings.vSyncCount = vSyncOn;
        Application.targetFrameRate = targetFrameRate;
        
        _levelStatusHandler = FindObjectOfType<LevelStatusHandler>();
        Physics.gravity = defaultGravity;
    }

    private void Start()
    {
        if(!_levelStatusHandler) return;
        StartSequence();
    }

    private void StartSequence()
    {
        StartCoroutine(_levelStatusHandler.CountdownSequence());
    }
}
