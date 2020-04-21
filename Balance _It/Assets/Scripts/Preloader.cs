using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {



	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3.0f;
	private GameObject WarningImage;

	private void Start()
	{
		
		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1;
		WarningImage = GameObject.Find ("WarningImage");
		WarningImage.SetActive (false);
		//preLoad the game
		// Some Code

		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;

	
	}

	private void Update()
	{
		// Fade In
		if (Time.time < minimumLogoTime) 
		{
			fadeGroup.alpha = 1 - Time.time;
		}


		// Fade Out
		if (Time.time > minimumLogoTime && loadTime != 0) 
		{
			fadeGroup.alpha = Time.time - minimumLogoTime;

			if (fadeGroup.alpha >= 1) 
			{
		//		WarningImage.SetActive (true);
				Invoke ("LoadMenu", 0);

			}
		}
	}

	private void LoadMenu()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}

}


