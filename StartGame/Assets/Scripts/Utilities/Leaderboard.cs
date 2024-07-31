using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;

public class Leaderboard : MonoBehaviour
{
    public void PostToLeaderboard(float newScore)
    {
        LeaderboardsService.Instance.AddPlayerScoreAsync("Times", newScore);
    }
}
