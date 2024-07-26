using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStatusHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    [SerializeField] private string[] counterDetails;
    [SerializeField] private string levelClearMessage;

    [SerializeField] private float timeBetweenDetails;
    [SerializeField] private float levelClearDuration;
    [SerializeField] private float targetFontSize;
    [SerializeField] private float fontSizeLerpSpeed;

    private WaitForSeconds _waitForDetails;
    private WaitForSeconds _waitForClearMessage;

    private PlayerInputController _inputController;

    private CameraFollow _cameraFollow;
    
    private SceneTransitions _sceneTransitions;

    private void Awake()
    {
        _sceneTransitions = FindObjectOfType<SceneTransitions>();
        _waitForDetails = new WaitForSeconds(timeBetweenDetails);
        _waitForClearMessage = new WaitForSeconds(levelClearDuration);
        _inputController = FindObjectOfType<PlayerInputController>();
        _cameraFollow = FindObjectOfType<CameraFollow>();
    }

    public IEnumerator CountdownSequence()
    {
        _cameraFollow.ChangeFollowSpeed(2f);
        _inputController.DisableInput();
        foreach (var detail in counterDetails)
        {
            counterText.text = detail;
            StartCoroutine(LerpFontSize());
            yield return _waitForDetails;

        }

        counterText.text = "";
        _inputController.EnableInput();
        StopAllCoroutines();
        _cameraFollow.ResetFollowSpeed();
    }

    public IEnumerator EndLevelSequence()
    {
        _inputController.DisableInput();
        counterText.text = levelClearMessage;
        StartCoroutine(LerpFontSize());
        yield return _waitForClearMessage;

        StartCoroutine(_sceneTransitions.FadeIntoNewScene());
    }

    private IEnumerator LerpFontSize()
    {
        counterText.fontSize = 0;
        while (true)
        {
            counterText.fontSize = Mathf.Lerp(counterText.fontSize, targetFontSize, fontSizeLerpSpeed * Time.fixedDeltaTime);
            
            yield return new WaitForFixedUpdate();
        }
    }
}
