using System;
using TMPro;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LeaderboardLoader : MonoBehaviour
{
    //private TMP_Text _leaderboardStats;
    [SerializeField] private TMP_Text leaderboardStatusText;

    [SerializeField] private GameObject leaderboardListing;
    [SerializeField] private Transform listingHandle;
    
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        listingHandle = GetComponentInChildren<VerticalLayoutGroup>().transform;
    }

    public async void FillLeaderboard()
    {
        try
        {
            var scores = await LeaderboardsService.Instance.GetScoresAsync("Times");
            
            leaderboardStatusText.text = "";
            foreach (var leaderboardEntry in scores.Results)
            {
                var totalTime = (int)leaderboardEntry.Score;
        
                var minutes = totalTime / 60;
                var seconds = totalTime - minutes * 60;
                var milliseconds = (int) ((leaderboardEntry.Score - totalTime) * 1000);

                string totalTimeString = string.Format($"{minutes:00}:{seconds:00}:{milliseconds:000}");

                var newListing = Instantiate(leaderboardListing, listingHandle).GetComponent<LeaderboardListing>();
                newListing.NameText.text = leaderboardEntry.PlayerName;
                newListing.TierText.text = "#" + (leaderboardEntry.Rank + 1);
                newListing.TimeText.text = totalTimeString;
            }
        }
        catch (Exception e)
        {
            leaderboardStatusText.text = "Post a score to view leaderboard";
            Debug.Log(e);
        }
    }
}
