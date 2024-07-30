using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeValue = 0f;
    private TMP_Text _timerText;

    private bool _gameStarted;

    private TimesHandler _timesHandler;
    private void Start()
    {
        _timerText = GetComponent<TMP_Text>();
        _timesHandler = FindObjectOfType<TimesHandler>();
    }

    private void Update()
    {
        if (!_gameStarted) return;
        _timeValue += Time.deltaTime;
        UpdateTimer(_timeValue);
    }
    
    private void UpdateTimer(float newTime)
    {
        var t0 = (int)newTime;
        var m = t0 / 60;
        var s = t0 - m * 60;
        var ms = (int) ((newTime - t0) * 1000);

        _timerText.text = $"{m:00}:{s:00}:{ms:000}";
    }

    public void StartTimer()
    {
        _gameStarted = true;
    }

    public void StopAndPostTimer()
    {
        _gameStarted = false;
        _timesHandler.AddToTimeList(_timeValue);
    }
}
