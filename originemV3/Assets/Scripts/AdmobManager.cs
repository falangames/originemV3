using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobManager : MonoBehaviour
{
    private RewardBasedVideoAd rewardedAd;
    public void Start()
    {
        rewardedAd = RewardBasedVideoAd.Instance;
        rewardedAd.OnAdRewarded += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        RequestRewardVideo();
    }
    public void ShowRewardVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
    private void RequestRewardVideo()
    {
        string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-6756320066958015/6690501438";
        #else
        adUnitId = "unexpected_platform";
        #endif
        rewardedAd.LoadAd(CreateNewRequest(), adUnitId);
    }
    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        StickControl.Instance.Revive();
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewardVideo();
    }
}
