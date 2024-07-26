using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ScoreHandler _scoreHandler;
    [SerializeField] private CollectableStatsSO _stats;

    private void Awake()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _scoreHandler.AddToScore(_stats.PointValue);
        Destroy(gameObject);
    }
}
