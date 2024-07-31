using TMPro;
using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;

public class LoginService : MonoBehaviour
{
    [SerializeField] private TMP_InputField signUpDisplayNameText;
    
    [SerializeField] private GameObject signUpScreen;

    private LeaderboardLoader _loader;
    
    private async void Awake()
    {
        _loader = FindObjectOfType<LeaderboardLoader>();
        await UnityServices.InitializeAsync();
        if (!AuthenticationService.Instance.IsAuthorized)
        {
            signUpScreen.SetActive(true);
            SignUpPlayer();
        }
        else
        {
            _loader.FillLeaderboard();
        }
        _loader.gameObject.SetActive(false);
    }

    private async void SignUpPlayer()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            _loader.FillLeaderboard();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    public async void UpdateUserDisplayName()
    {
        var displayName = signUpDisplayNameText.text;
        if (displayName.Length <= 0) return;
        await AuthenticationService.Instance.UpdatePlayerNameAsync(displayName);
        signUpScreen.SetActive(false);
    }
}
