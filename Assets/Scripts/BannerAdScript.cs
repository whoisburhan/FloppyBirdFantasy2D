using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour {
#if UNITY_ANDROID || UNITY_IOS

#if UNITY_ANDROID
    public string gameId = "4696457";
    public string placementId = "Banner_Android";
#elif UNITY_IOS
   // public string gameId = "4696456";
   // public string placementId = "Banner_iOS";
#endif
    
    public bool testMode = true;

    void Start () {
        // Initialize the SDK if you haven't already done so:
        Advertisement.Initialize (gameId, testMode);

        StartCoroutine (ShowBannerWhenReady ());
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (placementId)) {
            Debug.Log("ADS NOT LOADED");
            yield return new WaitForSeconds (0.5f);
        }
        Debug.Log("ADS  LOADED");
        Advertisement.Banner.SetPosition (BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show (placementId);
    }
#endif
}