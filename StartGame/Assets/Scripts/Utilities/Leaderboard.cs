using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;

public class Leaderboard : MonoBehaviour
{
    public async void PostToLeaderboard(float newScore)
    {
        try
        {
            await LeaderboardsService.Instance.AddPlayerScoreAsync("Times", newScore);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
