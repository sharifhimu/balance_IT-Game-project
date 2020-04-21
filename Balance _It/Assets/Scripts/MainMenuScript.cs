using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    [Header("References")]
    [SerializeField] private LevelInfoHolder levelinfoHolder;
    [SerializeField] private ButtonSprites soundButtonSprites;

    [Header("Buttons")]
    [SerializeField] private GameObject modesButton;
    [SerializeField] private GameObject soundButton;

    [Header("Panels")]
    [SerializeField] private GameObject CharacterPanelHolder;
    [SerializeField] private GameObject moreGamesPanel;
    [SerializeField] private GameObject rateUsPanel;

    [Header("Texts")]
    [SerializeField] private Text CharacterPanelCoinText;

    private void Start()
    {
      //  UnlockLevels();
        InitPanels();
        UpdateUIValues();
        HandleRateUs();
    }

    public void Update()
    {
        ExitWithDoubleClick();
    }

    public static MainMenuScript instance;


    private void InitPanels()
    {
        instance = this;
        if (AudioManager.instance)
        {
            if (Scores.Instance)
            {
                if (Scores.Instance.records.is_sound_Active)
                    AudioManager.instance.Play("music");
            }
            else
            {
                AudioManager.instance.Play("music");
            }
        }
        ActivateCoinPanel(false);
        ActivateMoreGamesPanel(false);
        rateUsPanel.SetActive(false);
        HandleSound();
    }

    private void ActivateCoinPanel(bool flag)
    {
        CharacterPanelHolder.SetActive(flag);
    }

    private void ActivateMoreGamesPanel(bool flag)
    {
        moreGamesPanel.SetActive(flag);
    }

    public void ModesPressed()
    {
        ButtionSound();
        Invoke("GotoModes", .3f);
    }

    private void GotoModes()
    {
        SceneManager.LoadScene("ModesMenu");
        if (Scores.Instance)
            Scores.Instance.settings.newLevelUnlock = false;
    }

    public void MoreGamesPressed()
    {
        ActivateMoreGamesPanel(true);
    }

    private void UpdateUIValues()
    {
        if (Scores.Instance)
        {
          
            CharacterPanelCoinText.text = Scores.Instance.records.coin.ToString();
        }
    }

    public void PlayPressed()
    {
        ButtionSound();
        if (Scores.Instance)
        {
            SceneManager.LoadScene("ModesMenu");
        }
        else
        {
            SceneManager.LoadScene("ModesMenu");
        }
    }

    public void BallPressed()
    {
        ButtionSound();
        ActivateCoinPanel(true);
    }

    public void BallBackPressed()
    {
        ButtionSound();
        ActivateCoinPanel(false);
    }

    public void SoundButtonPressed()
    {
        if(Scores.Instance)
        {
            Scores.Instance.records.is_sound_Active = !Scores.Instance.records.is_sound_Active;
            HandleSound();
        }
    }

    public void LikeUsPressed()
    {
        Application.OpenURL("https://www.facebook.com/Circle-Magic-1966245276816089/");
    }

    private void UnlockLevels()
    {
        if (Scores.Instance)
        {
            for (int i = 0; i < Scores.Instance.settings.levels.Length; i++)
            {
                if (!Scores.Instance.settings.levels[i].isUnlocked)
                {
                    if (levelinfoHolder.levelInfos[i].pointsNeedToUnlock <= Scores.Instance.records.totalScore)
                    {
                        Scores.Instance.settings.levels[i].isUnlocked = true;
                        Scores.Instance.settings.newLevelUnlock = true;
                    }
                }
            }

            if (Scores.Instance.settings.newLevelUnlock == true)
                modesButton.GetComponent<Animator>().SetBool("blnk", true);
            Scores.Instance.SaveSettingsBinaryData();
        }
    }


    public void HandleSound()
    {
        if (Scores.Instance)
        {
           
            if (Scores.Instance.records.is_sound_Active)
            {
                soundButton.GetComponent<Image>().sprite = soundButtonSprites.anciveSprite;
                AudioManager.instance.Play("music");
            }
            else
            {
                soundButton.GetComponent<Image>().sprite = soundButtonSprites.inactiveSprite;
                AudioManager.instance.Pause("music");
            }
        }
        else
            Debug.Log("cound not handle sound sprite cos scores was not found");
    }

    private void ButtionSound()
    {
        if (Scores.Instance)
        {
            if (Scores.Instance.records.is_sound_Active)
            {
                AudioManager.instance.Play("button");
            }
        }
        else
        {
            AudioManager.instance.Play("button");
        }
    }

    public void UpdateInventoryCoinText()
    {
        if(Scores.Instance)
            CharacterPanelCoinText.text = Scores.Instance.records.coin.ToString();
    }

    float lastClickTime = 0;
    float catchTime = 3f;

    public void ExitWithDoubleClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.time - lastClickTime < catchTime)
            {
                //double click
                Application.Quit();
            }
            else
            {
                //normal click
                SSTools.ShowMessage("Press again to exit.", SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
            lastClickTime = Time.time;
        }
    }

    public int thresholdRateUS;
    

    public void HandleRateUs()
    {
        if(RateUs.Instance)
        {
            if(Application.internetReachability!=NetworkReachability.NotReachable)
            {
                if(RateUs.Instance.rateInfo.count>=thresholdRateUS && RateUs.Instance.rateInfo.is_Rated==false)
                {

                    rateUsPanel.SetActive(true);
                }
            }
            else
            {
                SSTools.ShowMessage("Please check your internet connection!", SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
        }
    }

    public void RateUsPressed()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.agamilabs.magicCircle&hl=en");
        if (RateUs.Instance)
        {
            RateUs.Instance.rateInfo.is_Rated = true;
            RateUs.Instance.SaveRateInfoBinaryData();
        }
    }

    public void NotNowPressed()
    {
        rateUsPanel.SetActive(false);
    }


}
