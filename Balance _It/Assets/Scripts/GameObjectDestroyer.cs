using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour {

    [SerializeField] private float DeactiveTime;

    private void OnEnable()
    {
        Invoke("DeactiveObject", DeactiveTime);
    }

    private void DeactiveObject()
    {
        gameObject.SetActive(false);
    }
}
