using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class GoalPost : MonoBehaviour
{
    private LevelStatusHandler _levelStatusHandler;

    private BoxCollider _thisCollider;
    
    [SerializeField] private string levelClearMessage;

    private TMP_Text _levelStatusText;

    [SerializeField] private Vector3 levelClearGravity;

    private CameraFollow _cameraFollow;

    private void Awake()
    {
        _levelStatusHandler = FindObjectOfType<LevelStatusHandler>();
        _cameraFollow = FindObjectOfType<CameraFollow>();
        _thisCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _thisCollider.enabled = false;
        _cameraFollow.RemoveFollow();
        Physics.gravity = levelClearGravity;
        StartCoroutine(_levelStatusHandler.EndLevelSequence());
    }
}
