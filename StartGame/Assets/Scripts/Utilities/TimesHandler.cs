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
        var totalTime = (int)_timeList.Sum();
        
        var minutes = totalTime / 60;
        var seconds = totalTime - minutes * 60;
        var milliseconds = (int) ((_timeList.Sum() - totalTime) * 1000);

        string totalTimeString = string.Format($"{minutes:00}:{seconds:00}:{milliseconds:000}");

        if (!_leaderboard) _leaderboard = FindObjectOfType<Leaderboard>();
        
        _leaderboard.PostToLeaderboard(_timeList.Sum());
        Debug.LogFormat(totalTimeString);
    }
}
