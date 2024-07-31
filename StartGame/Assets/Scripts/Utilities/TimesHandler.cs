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
        
        CalculateTotalTimes();
    }

    private void CalculateTotalTimes()
    {
        if (!_leaderboard) _leaderboard = FindObjectOfType<Leaderboard>();
        
        _leaderboard.PostToLeaderboard(_timeList.Sum());
    }
}
