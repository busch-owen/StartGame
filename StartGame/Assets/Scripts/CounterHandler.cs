using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CounterHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    [SerializeField] private string[] counterDetails;

    [SerializeField] private float timeBetweenDetails;
    [SerializeField] private float targetFontSize;
    [SerializeField] private float fontSizeLerpSpeed;

    private WaitForSeconds _waitForDetails;

    private PlayerInputController _inputController;

    private CameraFollow _cameraFollow;

    private void Awake()
    {
        _waitForDetails = new WaitForSeconds(timeBetweenDetails);
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
            Debug.Log("Counting");
            StartCoroutine(LerpFontSize());
            yield return _waitForDetails;

        }

        counterText.text = "";
        _inputController.EnableInput();
        StopAllCoroutines();
        _cameraFollow.ResetFollowSpeed();
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
