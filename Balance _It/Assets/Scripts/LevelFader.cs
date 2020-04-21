using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour {

    public Animator animator;
    private string levelToLoad;

    private static LevelFader instance;

    public static LevelFader Instance
    {
        get
        {
            return instance;
        }
    }
    
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
    public void FadeToLevel(string levelToLoad)
    {
        this.levelToLoad = levelToLoad;
        animator.SetTrigger("fade_out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
