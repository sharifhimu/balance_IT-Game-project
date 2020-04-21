﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulturescript : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.SetTrigger("vul_attack");
        }
    }
}