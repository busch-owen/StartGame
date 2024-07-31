using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimesHandler : Singleton<TimesHandler>
{
    private List<float> _timeList = new();

    private Leaderboard _leaderboard;

    public void AddToTimeList(float timeToAdd)
    {
        _timeList.Add(timeToAdd);
    }

    public void CalculateTotalTimes()
    {
        if (!_leaderboard) _leaderboard = FindObjectOfType<Leaderboard>();
        Debug.Log(_timeList.Sum());
        _leaderboard.PostToLeaderboard(_timeList.Sum());
    }
}
