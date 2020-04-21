using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteGameManager : MonoBehaviour {

    [Header("References")]
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private BackgroundScroller background;
    [SerializeField] private PlatformScript platform;
    [SerializeField] private UIHolder uiHolder;
    [SerializeField] private PlayerInfo playerInfo;
    
    [SerializeField] CharacterScript roundCharacter;
    [SerializeField] private LevelInfos levelInfo;

    [Header("Variables")]
    [SerializeField]
    private int Score;

    private static InfiniteGameManager instance;

    public static InfiniteGameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public enum GameState
    {
        waitingToStart,
        running,
        paused,
        gameOver
    }

    public GameState gameState;

	// Use this for initialization
	void Start () {
        instance = this;
        Init();
	}

    private void Init()
    {
        obstacleSpawner.Init();
        background.Init();
        uiHolder.Init();
    }
	
	// Update is called once per frame
	void Update () {
		switch(gameState)
        {
            case GameState.waitingToStart:
                StartGameWithClick();
                break;
            case GameState.running:
                obstacleSpawner.CreateObstacle();
                obstacleSpawner.CreateSideObstacle();
                CountScore();
                break;
            case GameState.paused:
                break;
            case GameState.gameOver:
                break;
        }
	}

    void FixedUpdate()
    {
        switch (gameState)
        {
            case GameState.waitingToStart:
                break;
            case GameState.running:
                platform.ControlPlatform();
                break;
            case GameState.paused:
                break;
            case GameState.gameOver:
                break;
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Kill Player");
        initGameOver();
        roundCharacter.KillPlayer();
    }

    private void StartGameWithClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GotoRunning();
            uiHolder.ActivateMainPanel(true);
            uiHolder.ActivateGameStartPanel(false);
            PlayAudio("background");
            // do more staff to start the game
        }
    }

    public void initGameOver()
    {
        uiHolder.ActivateGameoverPanel(true);
     //   AudioManager.instance.Pause("background");
     //   AudioManager.instance.Play("gameOver");
        GotoGameOver();
        playerInfo.canMove = false;
    }


    public void GotoGameOver()
    {
        gameState = GameState.gameOver;
    }

    public void GoToPause()
    {
        gameState = GameState.paused;
    }

    public void GotoRunning()
    {
        gameState = GameState.running;
    }

    public void PlayAudio(string audio)
    {
        if(AudioManager.instance)
        {
            AudioManager.instance.Play(audio);
        }
    }

    public void PauseAudio(string audio)
    {
        if(AudioManager.instance)
        {
            AudioManager.instance.Pause(audio);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level" + levelInfo.levelIndex + "Inf");
    }

    public void CountScore()
    {
        Score +=  (int) (60 * Time.deltaTime);
        uiHolder.UpdateScoreText(Score);
    }
}
