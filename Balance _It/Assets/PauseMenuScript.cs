﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour {

    public void HomeButtonPressing()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
