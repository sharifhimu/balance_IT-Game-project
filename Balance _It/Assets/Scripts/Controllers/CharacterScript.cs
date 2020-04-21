using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    [SerializeField] private GameObject splash;

    private void Start()
    {
     //  splash = transform.GetChild(0).gameObject;
        splash.SetActive(false);
    }

    public void KillPlayer()
    {
        splash.SetActive(true);
        splash.transform.SetParent(null);
        gameObject.SetActive(false);
    }

    public void InitGameComplete()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //  rb.gravityScale = 0;
        rb.isKinematic = true;
      //  GetComponent
    }
}
 