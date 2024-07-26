using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private SceneTransitions _sceneTransitions;

    private void Awake()
    {
        _sceneTransitions = FindObjectOfType<SceneTransitions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        StartCoroutine(_sceneTransitions.FadeIntoSameScene());
    }
}
