using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixFrameRate : MonoBehaviour {

    public int targetFrameRate;

	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;

	}
	
	// Update is called once per frame
	void Update () {
        if (targetFrameRate != Application.targetFrameRate)
        {
            Application.targetFrameRate = targetFrameRate;
        }
	}
}
