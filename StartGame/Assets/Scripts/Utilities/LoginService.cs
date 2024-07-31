using TMPro;
using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using UnityEditor.PackageManager;

public class LoginService : MonoBehaviour
{
    [SerializeField] private TMP_InputField
        signInUsernameText,
        signInPasswordText,
        signUpUsernameText,
        signUpPasswordText,
        signUpDisplayNameText;
    
    [SerializeField] private TMP_Text errorDisplayText;

    [SerializeField] private GameObject signInScreen;
    [SerializeField] private GameObject signUpScreen;

    private LeaderboardLoader _loader;
    
    private async void Awake()
    {
        _loader = FindObjectOfType<LeaderboardLoader>();
        await UnityServices.InitializeAsync();
        //AuthenticationService.Instance.SignOut();
        if (!AuthenticationService.Instance.IsAuthorized)
        {
            signInScreen.SetActive(true);
        }
        errorDisplayText.text = "";
    }

    public async void SignUpPlayer()
    {
        errorDisplayText.text = "";
        var username = signUpUsernameText.text;
        var password = signUpPasswordText.text;
        var displayName = signUpDisplayNameText.text;

        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            await AuthenticationService.Instance.UpdatePlayerNameAsync(displayName);
            _loader.FillLeaderboard();
            signUpScreen.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
            errorDisplayText.text =
                "Invalid username or password, username must contain at least 3 characters and a maximum of 20 characters. Password must contain a capital letter, a lowercase letter, a number and a special character";
        }
    }

    public async void PlayAsGuest()
    {
        errorDisplayText.text = "";
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        _loader.FillLeaderboard();
    }

    public async void LogInPlayer()
    {
        errorDisplayText.text = "";
        var username = signInUsernameText.text;
        var password = signInPasswordText.text;
        
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            _loader.FillLeaderboard();
            signInScreen.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
            errorDisplayText.text =
                "Incorrect username or password, try again or create a new account";
        }
        
    }
}
