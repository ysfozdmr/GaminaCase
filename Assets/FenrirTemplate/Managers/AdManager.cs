using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;
using System;


namespace Fenrir.Managers
{
    public class AdManager : MonoBehaviour
    {
        private InterstitialAd _interstitialAd;
        private AdRequest adRequest;
        public string appID;

        private void Start()
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                LoadInterstitialAd();
            });
        }


        public void LoadInterstitialAd()
        {
            // Clean up the old ad before loading a new one.
            if (_interstitialAd != null)
            {
                _interstitialAd.Destroy();
                _interstitialAd = null;
            }

            Debug.Log("Loading the interstitial ad.");

            // create our request used to load the ad.
            var adRequest = new AdRequest.Builder()
                .AddKeyword("unity-admob-sample")
                .Build();

            // send the request to load the ad.
            InterstitialAd.Load(appID, adRequest,
                (InterstitialAd ad, LoadAdError error) =>
                {
                    // if error is not null, the load request failed.
                    if (error != null || ad == null)
                    {
                        Debug.LogError("interstitial ad failed to load an ad " +
                                       "with error : " + error);
                        return;
                    }

                    Debug.Log("Interstitial ad loaded with response : "
                              + ad.GetResponseInfo());

                    _interstitialAd = ad;
                });
        }
        private void RegisterReloadHandler(InterstitialAd ad)
        {
            // Raised when the ad closed full screen content.
            ad.OnAdFullScreenContentClosed += ()=>
            {
                Debug.Log("Interstitial Ad full screen content closed.");

                // Reload the ad so that we can show another as soon as possible.
                LoadInterstitialAd();
            };
            // Raised when the ad failed to open full screen content.
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Debug.LogError("Interstitial ad failed to open full screen content " +
                               "with error : " + error);

                // Reload the ad so that we can show another as soon as possible.
                LoadInterstitialAd();
            };
        }
        public void ShowInterstitial()
        {
            if (_interstitialAd != null && _interstitialAd.CanShowAd())
            {
                Debug.Log("Showing interstitial ad.");
                _interstitialAd.Show();
            }
            else
            {
                Debug.LogError("Interstitial ad is not ready yet.");
            }
        }
       
    }
}
