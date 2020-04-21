using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public void RestartPressed()
    {
        //if (GameManager.Instance)
        //    SceneManager.LoadScene("Level" + GameManager.Instance.levelInfo.levelIndex);
        Time.timeScale = 1;
    }

    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void PausePressed()
    {
        GetComponent<UIHolder>().ActivatePausePanel(true);
        Time.timeScale = 0;
    //    GameManager.Instance.PauseSound("music");
    }

    public void ResumePressed()
    {
        GetComponent<UIHolder>().ActivatePausePanel(false);
        Time.timeScale = 1;
    //    GameManager.Instance.PlaySound("music");
    }

    public void SoundPressed()
    {
        if(Scores.Instance)
        {
            
            Scores.Instance.records.is_sound_Active = !Scores.Instance.records.is_sound_Active;
           // GetComponent<UIHolder>().HandleSound();
        }
    }

    public void OnBackPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePressed();
        }
    }


}
