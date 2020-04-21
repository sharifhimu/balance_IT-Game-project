using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject background, leftWall, rightWall;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject blastEffect;
    [SerializeField] private GameObject[] blade;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject startPanel, gamePanel, GameOverPanel;
    
    [SerializeField] private float speed;
    [SerializeField] private Text scoreText;


    private int score;
    private bool gameStarted;
    private float waitingTime, delayTime;
    private static GameManager instance;
    

    public static GameManager Instance
    {
        get {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        delayTime = 5;
        waitingTime = 3;
    }

    // Use this for initialization
    void Start () {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        HandleUI();
        if (gameStarted)
        {
            SpawnObstacles();
        }

	}

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            MoveBackground();
            RotateBase();
        }
    }

    private void MoveBackground()
    {
        //background.GetComponent<Material>().mainTextureOffset = new Vector2(background.GetComponent<Material>().mainTextureOffset.x, background.GetComponent<Material>().mainTextureOffset.y+ 0.02f);
        background.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(background.GetComponent<Renderer>().material.mainTextureOffset.x, background.GetComponent<Renderer>().material.mainTextureOffset.y + speed*Time.deltaTime);
        leftWall.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(leftWall.GetComponent<Renderer>().material.mainTextureOffset.x, leftWall.GetComponent<Renderer>().material.mainTextureOffset.y + speed * Time.deltaTime);
        rightWall.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(rightWall.GetComponent<Renderer>().material.mainTextureOffset.x, rightWall.GetComponent<Renderer>().material.mainTextureOffset.y + speed * Time.deltaTime);
    }

    public float rotationSpeed;
    private float h;
    private void RotateBase()
    {
        float hor = CnControls.CnInputManager.GetAxis("Horizontal");

        
        ground.transform.Rotate(0, 0, -hor * rotationSpeed * Time.deltaTime);
        if (ground.transform.eulerAngles.z > 10 && ground.transform.eulerAngles.z < 20)
            ground.transform.eulerAngles = new Vector3(ground.transform.eulerAngles.x, ground.transform.eulerAngles.y, 10);
        else if (ground.transform.eulerAngles.z < 350 && ground.transform.eulerAngles.z > 340)
        {
            
            ground.transform.eulerAngles = new Vector3(ground.transform.eulerAngles.x, ground.transform.eulerAngles.y, 350);
        }
    }

    public void killCharacter()
    {
        gameStarted = false;
        Instantiate(blastEffect, ball.transform.position, ball.transform.rotation);
        ball.SetActive(false);
        Invoke("ShowGameOver", 1);
    }

    private void HandleUI()
    {
        scoreText.text = "SCORE: " + score;
    }

    private void SpawnObstacles()
    {
        waitingTime -= Time.deltaTime;

        if (waitingTime < 0.0f)
        {
            int spIndx = Random.Range(0, 3);
            int bladeIndx = Random.Range(0, blade.Length);

            while (blade[bladeIndx].activeInHierarchy)
            {
                bladeIndx = Random.Range(0, blade.Length);
            }

            blade[bladeIndx].SetActive(true);
            blade[bladeIndx].transform.position = spawnPoints[spIndx].position;
            blade[bladeIndx].GetComponent<ObstacleMover>().SetSpeed(1);
            waitingTime = delayTime;
        }

    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }

    private void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void PlayPressed()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameStarted = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
        PlayPressed();
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
