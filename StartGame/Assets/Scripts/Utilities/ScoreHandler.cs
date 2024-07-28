using System;
using UnityEngine;

public class ScoreHandler : Singleton<ScoreHandler>
{
    private int _score;

    private CerealCounter _cerealCounter;

    public void AssignCounter(CerealCounter newCounter)
    {
        _cerealCounter = newCounter;
    }
    
    public void RefreshScore()
    {
        if (!_cerealCounter)
        {
            _cerealCounter = FindObjectOfType<CerealCounter>();
        }
        _cerealCounter.UpdateCounterText(_score);
    }

    public void AddToScore(int amount)
    {
        _score += amount;
        RefreshScore();
    }
}
