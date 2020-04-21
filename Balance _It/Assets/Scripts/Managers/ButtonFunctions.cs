using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    UIHolder uIHolder;

    private void Start()
    {
        uIHolder = GetComponent<UIHolder>();
    }

    public void PausePressed()
    {
        if (GameManagerArcade.Instance)
        {
            GameManagerArcade.Instance.GoToPause();
            uIHolder.ActivatePausePanel(true);
            Time.timeScale = 0;
        }

    }

    public void ResumePressed()
    {
        if (GameManagerArcade.Instance)
        {
            GameManagerArcade.Instance.GoToRunning();
            uIHolder.ActivatePausePanel(false);
            Time.timeScale = 1;
        }

    }

    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartPressed()
    {
        if (GameManagerArcade.Instance)
        {
            GameManagerArcade.Instance.RestartLevel();
        }
    }

    public void GameCompleteNextPressed()
    {

    }

    public void InfRestartPressed()
    {
        if (InfiniteGameManager.Instance)
        {
            InfiniteGameManager.Instance.RestartLevel();
        }
    }
}
