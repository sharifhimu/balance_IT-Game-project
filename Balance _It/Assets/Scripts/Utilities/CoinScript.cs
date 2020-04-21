using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    [SerializeField] private GameObject splash;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(GameManagerArcade.Instance)
            {
                splash.transform.SetParent(null);
                splash.SetActive(true);
                gameObject.SetActive(false);

                GameManagerArcade.Instance.IncreaseCoins(1);
                AudioManager.instance.Play("coin");
            }
        }
    }
}