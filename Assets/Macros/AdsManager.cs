using Ludiq;
using Bolt;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string placement = "rewardedVideo";
    private AudioSource audioSource;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3537705", true);
        audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
    }

    public void showAd(string p)
    {
        Advertisement.Show(p);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            int newRings = (int)Variables.Saved.Get("savedRings");
            newRings += 10;
            Variables.Saved.Set("savedRings", newRings);
            audioSource.mute = false;
            
        }
        else if (showResult == ShowResult.Failed)
        {
            //oh no!
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        audioSource.mute = true;
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }
}
