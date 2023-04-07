using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

namespace Fenrir.Managers
{
    public class AdManager : MonoBehaviour
    {

        public string iosInterstitialID;
        public string androidInterstititialID;

        private InterstitialAd interstitial;

        void Start()
        {
            DontDestroyOnLoad(this.transform);

            MobileAds.Initialize(initStatus => { print("admob inited"); });

            StartCoroutine(DelayedLoad());
        }

        private void RequestInterstitial()
        {
#if UNITY_ANDROID
            string adUnitId = androidInterstititialID;
#elif UNITY_IPHONE
        string adUnitId = iosInterstitialID;

#endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }

        IEnumerator DelayedLoad()
        {
            yield return new WaitForSeconds(0.5f);
            RequestInterstitial();
        }

        public void ShowInterstitial()
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
                RequestInterstitial();
            }
        }




    }

}
