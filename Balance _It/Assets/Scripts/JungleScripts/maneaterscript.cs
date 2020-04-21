using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maneaterscript : MonoBehaviour {

    Animator anim;
    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetTrigger("bite");
            AudioManager.instance.Play("treeBite");
        }
    }
}