using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NewBehaviourScript : MonoBehaviour
{

#if UNITY_IOS
string adUnitIdTest = "ef20756bc266242c";
#elif UNITY_ANDROID
string adUnitIdTest = "6b05ae7a0bf3f276";
#endif
    void Start()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) => {
            InitializeInterstitialAds();
        };

        MaxSdk.SetSdkKey("i5rv5A3kmLsSHaPHEVzuMoNBquz1mbUhin3U0Ot8JWqE1ii8AcSeMSUn9FuLeGSPAxxWvAW36My_MND1TWAKST");
        MaxSdk.InitializeSdk();

#if UNITY_IOS
                        
#elif UNITY_ANDROID
        var sdk = new AndroidJavaClass("com.startapp.sdk.adsbase.StartAppSDK");
        sdk.CallStatic("setTestAdsEnabled", true);
#endif
    }

    // Update is called once per frame
    void Update()
    {
    }

    int retryAttempt;

    public void InitializeInterstitialAds()
    {
      MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
      MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
      MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
      MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
      MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
      MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

      LoadInterstitial();
    }

    private void LoadInterstitial()
    {
      MaxSdk.LoadInterstitial(adUnitIdTest);
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
      retryAttempt = 0;

        if ( MaxSdk.IsInterstitialReady(adUnitId) )
        {
            MaxSdk.ShowInterstitial(adUnitId);
        }
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
      retryAttempt++;
      double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

      Invoke("LoadInterstitial", (float) retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {}

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {}

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
    }
}
