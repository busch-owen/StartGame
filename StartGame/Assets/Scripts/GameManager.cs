using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CounterHandler _counterHandler;

    private void Awake()
    {
        _counterHandler = FindObjectOfType<CounterHandler>();
    }

    private void Start()
    {
        StartSequence();
    }

    private void StartSequence()
    {
        StartCoroutine(_counterHandler.CountdownSequence());
    }
}
