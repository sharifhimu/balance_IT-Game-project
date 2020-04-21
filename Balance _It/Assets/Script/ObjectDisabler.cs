using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour {

    public float disableTime = 1;

    private void OnEnable()
    {
        Invoke("Disable", 1);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
