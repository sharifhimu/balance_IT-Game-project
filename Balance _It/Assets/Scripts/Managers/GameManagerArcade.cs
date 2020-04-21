using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerArcade: MonoBehaviour {

    private static GameManagerArcade instance;

    public static GameManagerArcade Instance
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
        gameOver,
        gameComplete,

    }

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private GameState gameState;
                                                                       
    [SerializeField] UIHolder uiHolder;

    [SerializeField] CharacterScript roundCharacter;

    [SerializeField] int totalCoins;
    [SerializeField] int oneStarCoins;
    [SerializeField] int twoStarCoins;
    [SerializeField] int threeStarCoins;

    

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        gameState = GameState.waitingToStart;
        Init();
    }

    private void Update()
    {
        switch(gameState)
        {
            case GameState.waitingToStart:
                StartGame();
                break;
            case GameState.running:
                break;
            case GameState.paused:
                break;
            case GameState.gameOver:
                break;
            case GameState.gameComplete:
                break;
        }
    }

    private void Init()
    {
        uiHolder.Init();
        
        playerInfo.coins = 0;
        playerInfo.stars = 0;
        playerInfo.score = 0;
        playerInfo.life = 1;
        playerInfo.canMove = false;
        AudioManager.instance.Play("background");
        roundCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScript>();
     //   GoToRunning();
        
        uiHolder.HandleCoinBar(playerInfo.coins, totalCoins);

    }

    public void StartGame()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GoToRunning();
            uiHolder.ActivateGameStartPanel(false);
            uiHolder.ActivateMainPanel(true);
  
        }
    }

    public int getScore()
    {
        return playerInfo.score;
    }

    public void IncreaseScore(int score)
    {
        playerInfo.score += score;
    }

    public int getCoins()
    {
        return playerInfo.coins;
    }

    public void IncreaseCoins(int coin)
    {
        playerInfo.coins += coin;
        uiHolder.HandleCoinBar(playerInfo.coins, totalCoins);
    //    uiHolder.updateCoinText(playerInfo.coins);
    }

    public int GetStars()
    {
        return playerInfo.stars;
    }

    public void IncreaseStars(int stars)
    {
        playerInfo.stars += stars;
    }

    public PlayerInfo GetPlayerInfo()
    {
        return playerInfo;
    }

    public CharacterScript GetRoundCharacter()
    {
        return roundCharacter;
    }

    public void GoToRunning()
    {
        gameState = GameState.running;
        playerInfo.canMove = true;
    }

    public void GoToPause()
    {
        gameState = GameState.paused;
        playerInfo.canMove = false;
    }

    public void GotoGameOver()
    {
        gameState = GameState.gameOver;
        playerInfo.canMove = false;
    }

    public void GotoGameComplete()
    {
        gameState = GameState.gameComplete;
        InitGameComplete();
        
    }

    public void KillPlayer()
    {
        initGameOver();
        roundCharacter.KillPlayer();
        
    }

    public void initGameOver()
    {
        uiHolder.ActivateGameoverPanel(true);
        AudioManager.instance.Pause("background");
        AudioManager.instance.Play("gameOver");
        GotoGameOver();
        playerInfo.canMove = false;
    }

    public void InitGameComplete()
    {
        playerInfo.canMove = false;
        uiHolder.ActivateGamecompletePanel(true);
        AudioManager.instance.Pause("background");
        AudioManager.instance.Play("win");
        roundCharacter.InitGameComplete();
        int star = 0;
        if(playerInfo.coins >= totalCoins-3)
        {
            Debug.Log("Got three stars");
            star = 3;
        }
        else if(playerInfo.coins >= (totalCoins*2)/3)
        {
            Debug.Log("Got two stars");
            star = 2;
        }
        else if(playerInfo.coins >= totalCoins/3)
        {
            Debug.Log("Got one stars");
            star = 1;
        }

        Debug.Log("Total coin: " + (totalCoins * 2) / 3);

        uiHolder.AssignLevelCompleteValues(playerInfo.score, playerInfo.coins, playerInfo.gem, star );
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(playerInfo.currentLevel);
    }




}
