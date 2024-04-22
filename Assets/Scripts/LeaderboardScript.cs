using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderboardScript : MonoBehaviour
{
    public IntVariable score;
    /*
    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void AddScoreWithMetadata(string playerName)
    {
        var metadata = new Dictionary<string, string>() { {"name", playerName} };
        var playerEntry = await LeaderboardsService.Instance
            .AddPlayerScoreAsync(
                "leaderboardID",
                score.i,
                new AddPlayerScoreOptions { Metadata = metadata });
        Debug.Log(JsonConvert.SerializeObject(playerEntry));
    }*/
}