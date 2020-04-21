using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHolder : MonoBehaviour {

    [Header("Panels")]
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject pausePanel, gameOverPanel, gameCompletePanel, gameStartPanel;

    [Header("StarHolders")]
    [SerializeField] GameObject threeStarHolder;
    [SerializeField] GameObject twoStarHolder, oneStarHolder;

    [Header("Texts")]
    [SerializeField] Text mainCoinText;
    [SerializeField] Text mainScoreText;
    [SerializeField] Text levelCompleteScoreText, levelCompleteCoinText, levelCompleteGemText;

    [Header("Images")]
    [SerializeField] Image coinBar;


    public void ActivateMainPanel(bool flag)
    {
        mainPanel.SetActive(flag);
    }

    public void ActivatePausePanel(bool flag)
    {
        pausePanel.SetActive(flag);
    }

    public void ActivateGameoverPanel(bool flag)
    {
        gameOverPanel.SetActive(flag);
    }

    public void ActivateGamecompletePanel(bool flag)
    {
        gameCompletePanel.SetActive(flag);
    }

    public void ActivateGameStartPanel(bool flag)
    {
        gameStartPanel.SetActive(flag);
    }
   
    public void Init()
    {
        ActivateMainPanel(false);
        ActivatePausePanel(false);
        ActivateGameoverPanel(false);
        ActivateGamecompletePanel(false);
        ActivateGameStartPanel(true);
        updateCoinText(0);
    }

    public void updateCoinText(int score)
    {
        mainCoinText.text = score.ToString();
    }

    public void UpdateScoreText(int score)
    {
        mainScoreText.text = score.ToString();
    }

    public void HandleCoinBar(int coin, int totalCoin)
    {
        coinBar.transform.localScale = new Vector3((float) coin / totalCoin, coinBar.transform.localScale.y, coinBar.transform.localScale.z);
    }


    public void AssignLevelCompleteValues(int score, int coin, int gem, int stars)
    {
        levelCompleteScoreText.text = score.ToString();
        levelCompleteCoinText.text = coin.ToString();
        levelCompleteGemText.text = gem.ToString();

        if(stars == 3)
        {
            threeStarHolder.SetActive(true);
        }
        else if(stars == 2)
        {
            twoStarHolder.SetActive(true);
        }
        else if(stars == 1)
        {
            oneStarHolder.SetActive(true);
        }
    }

    
	
}
