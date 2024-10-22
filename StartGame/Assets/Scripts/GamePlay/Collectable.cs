using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ScoreHandler _scoreHandler;
    [SerializeField] private CollectableStatsSO _stats;
    [SerializeField] private ParticleSystem collectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!_scoreHandler)
        {
            _scoreHandler = FindObjectOfType<ScoreHandler>();
        }

        Instantiate(collectEffect, transform.position, Quaternion.identity);
        _scoreHandler.AddToScore(_stats.PointValue);
        
        Destroy(gameObject);
    }
}
