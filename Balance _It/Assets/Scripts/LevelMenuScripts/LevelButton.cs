using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    public int id;
    public Text name;
    public Image bestScoreImage;
    public Image lockedImage;
    public Text scoreText;
    public Image themeImage;


    public void ThisButtonPressed()
    {
        SceneManager.LoadScene("Level" +id);
    }

    public void InitButton(string nm, bool isUnlocked, int points, int id, Sprite theme)
    {
        name.text = nm;
        this.id = id;
        if(isUnlocked)
        {
            bestScoreImage.gameObject.SetActive(true);
            lockedImage.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            themeImage.gameObject.SetActive(true);
            scoreText.text = points.ToString();
            GetComponent<Button>().interactable = true;
        }
        else
        {
            bestScoreImage.gameObject.SetActive(false);
            lockedImage.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            GetComponent<Button>().interactable = false;
        }
    }
}
