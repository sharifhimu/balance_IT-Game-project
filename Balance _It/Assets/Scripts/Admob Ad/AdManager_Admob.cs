//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using admob;
//using UnityEngine.UI;
//public class AdManager_Admob : MonoBehaviour
//{

//    private static AdManager_Admob instance;

//    public static AdManager_Admob Instance
//    {
//        get
//        {
//            return instance;
//        }
//    }

//    // interstitial test ad: ca-app-pub-3940256099942544/1033173712
//    // test banner ad: ca-app-pub-3940256099942544/6300978111

//    [SerializeField] private string BannerID;
//    [SerializeField] private string videoID;
//    [SerializeField] private string rewardVideoID;
//    private const string TestRewardVideoID = "ca-app-pub-3940256099942544/5224354917";

//    public string msg;
//    // Use this for initialization
//    void Start()
//    {
//      //  videoID = "ca-app-pub-3940256099942544/1033173712";
//        instance = this;
//        DontDestroyOnLoad(gameObject);
//        Admob.Instance().rewardedVideoEventHandler += onInterstitialEvent;
//        Admob.Instance().initAdmob(BannerID, videoID);
//        Admob.Instance().setTesting(false);
//        LoadInterstetial();
//        LoadRewardVideo();

//    }

//    void onInterstitialEvent(string eventName, string msg)
//    {
//        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
//        if (eventName == AdmobEvent.onRewardedVideoCompleted)
//        {
            
//        }
//        else if(eventName == AdmobEvent.onAdClosed)
//        {

//        }
//    }

//    public void ShowBanner()
//    {
////#if UNITY_EDITOR
//  //      Debug.Log("Unable to play Ads from Editor");
////#elif UNITY_ANDROID
//        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
////#endif

//    }

//    public void ShowVideo()
//    {

//        if (Admob.Instance().isInterstitialReady())
//        {
//            Admob.Instance().showInterstitial();
//        }
//    }

////    public void ShowRewardVideoForDoubleCoin()
////    {

////#if UNITY_EDITOR
////        Debug.Log("Unable to play reward Ads from Editor");
////#elif UNITY_ANDROID
////#endif
////        if (Admob.Instance().isRewardedVideoReady())
////        {
////            Admob.Instance().showRewardedVideo();
////            AI.GameManager.Instance.AddDoubleCoin();
////            UIScript.Instance.DeactivateDoubleCoinButton();
////            if(AI.GameManager.Instance.IsMissionFailed())
////            {
////                AI.GameManager.Instance.StartGameafterRevive();
////            }
////        }
////        else
////        {
////            UIScript.Instance.ShowRewardFailedPanel("Video not available\nTry again");
////            LoadRewardVideo();
////        }

////    }

//    public void ShowRewardVideoForResume()
//    {

//#if UNITY_EDITOR
//        Debug.Log("Unable to play reward Ads from Editor");
//#elif UNITY_ANDROID

//        if (Admob.Instance().isRewardedVideoReady())
//        {
//            Admob.Instance().showRewardedVideo();
//    }
//        else
//        {
//            LoadRewardVideo();
//}
//#endif
       
//    }

//    public void LoadInterstetial()
//    {
//        if(!Admob.Instance().isInterstitialReady())
//            Admob.Instance().loadInterstitial();
//    }

//    public void LoadRewardVideo()
//    { 
//       // Admob.Instance().loadRewardedVideo(rewardVideoID);
//       if(!Admob.Instance().isRewardedVideoReady())
//            Admob.Instance().loadRewardedVideo(TestRewardVideoID);
//    }

//    public bool CheckRewardVideoReady()
//    {
//        if (Admob.Instance().isRewardedVideoReady())
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//}
