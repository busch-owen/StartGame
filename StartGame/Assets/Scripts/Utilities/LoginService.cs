using TMPro;
using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;

public class LoginService : MonoBehaviour
{
    [SerializeField] private TMP_InputField signUpDisplayNameText;
    
    [SerializeField] private GameObject signUpScreen;
    [SerializeField] private TMP_Text welcomeText;

    private LeaderboardLoader _loader;
    
    private async void Awake()
    {
        _loader = FindObjectOfType<LeaderboardLoader>();
        await UnityServices.InitializeAsync();
        if (!AuthenticationService.Instance.IsAuthorized)
        {
            SignUpPlayer();
        }
        else
        {
            _loader.FillLeaderboard();
            RefreshName();
        }
        _loader.gameObject.SetActive(false);
    }

    private async void SignUpPlayer()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            _loader.FillLeaderboard();
            RefreshName();
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    public async void RefreshName()
    {
        try
        {
            var newName = await AuthenticationService.Instance.GetPlayerNameAsync();
            Debug.Log(newName);
            welcomeText.text = "Welcome: " + newName + "!";
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    
    public async void UpdateUserDisplayName()
    {
        try
        {
            var displayName = signUpDisplayNameText.text;
            if (displayName.Length <= 0) return;
            await AuthenticationService.Instance.UpdatePlayerNameAsync(displayName);
            signUpScreen.SetActive(false);
            RefreshName();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        
    }
}
