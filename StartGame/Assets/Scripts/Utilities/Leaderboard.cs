using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;

public class Leaderboard : MonoBehaviour
{
    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        if (AuthenticationService.Instance.IsAuthorized) return;
        //await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync("buschowen", "MyNuts69*");
        await AuthenticationService.Instance.SignInWithUsernamePasswordAsync("buschowen", "MyNuts69*");
    }

    public void PostToLeaderboard(float newScore)
    {
        LeaderboardsService.Instance.AddPlayerScoreAsync("Times", newScore);
        Debug.Log(LeaderboardsService.Instance.GetPlayerScoreAsync("Times").Result);
        //LeaderboardsService.Instance.GetPlayerScoreAsync("Times")
    }
}
