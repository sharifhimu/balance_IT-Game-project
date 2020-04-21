using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionMenu : MonoBehaviour {

    [SerializeField] private Text[] HighScoreTexts;

    [SerializeField] private LevelInfoHolder levelInfoHolder;

    [SerializeField] private LevelButton[] levelButtons;

    private void Start()
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
        InitializeLevelButton();
    }


    private void Update()
    {
        OnBackPressed();   
    }


    private void InitializeLevelButton()
    {
        if (Scores.Instance)
        {
            levelButtons[0].InitButton(levelInfoHolder.levelInfos[0].levelName, Scores.Instance.settings.levels[0].isUnlocked, Scores.Instance.settings.levels[0].highscore, levelInfoHolder.levelInfos[0].levelIndex,levelInfoHolder.levelInfos[0].themeImage);
        }
        //else
        //{
        //    for (int i = 0; i < levelButtons.Length; i++)
        //    {
        //        levelButtons[i].InitButton(levelInfoHolder.levelInfos[i].name, true, 100, levelInfoHolder.levelInfos[i].levelIndex);
        //    }
        //}
    }

    public void AssigneHighScores(int indx)
    {

    }

    public void MainMenuPressed()
    {
        ButtonSound();
        SceneManager.LoadScene("MainMenu");
    }

    private void ButtonSound()
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

    public void OnBackPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenuPressed();
        }
    }

    public void NextPressed()
    {
        if (Scores.Instance)
        {
            levelButtons[1].InitButton(levelInfoHolder.levelInfos[1].levelName, Scores.Instance.settings.levels[1].isUnlocked, Scores.Instance.settings.levels[1].highscore, levelInfoHolder.levelInfos[1].levelIndex, levelInfoHolder.levelInfos[1].themeImage);
        }
    }

    public void PreviousPressed()
    {
        if (Scores.Instance)
        {
            levelButtons[0].InitButton(levelInfoHolder.levelInfos[0].levelName, Scores.Instance.settings.levels[0].isUnlocked, Scores.Instance.settings.levels[0].highscore, levelInfoHolder.levelInfos[0].levelIndex, levelInfoHolder.levelInfos[0].themeImage);
        }
    }

}
