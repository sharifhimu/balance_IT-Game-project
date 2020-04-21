using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorpionattack : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
		
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetTrigger("scor_attack");
           // AudioManager.instance.Play("beeBite");
        }
    }
}
