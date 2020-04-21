using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour {

    Animator anim;
    [SerializeField] AudioSource idleaudio;
    private void Start()
    {
        anim = GetComponent<Animator>();
        idleaudio = GetComponent<AudioSource>();
        //AudioManager.instance.Play("beeIdle");
    }

    private void Update()
    {
        Debug.Log((transform.position.y - GameManagerArcade.Instance.GetRoundCharacter().transform.position.y));
        if ((transform.position.y - GameManagerArcade.Instance.GetRoundCharacter().transform.position.y) < 12 && (transform.position.y - GameManagerArcade.Instance.GetRoundCharacter().transform.position.y) > -2)
        {
            Debug.Log(transform.position.y - GameManagerArcade.Instance.GetRoundCharacter().transform.position.y);
           // idleaudio.mute = false ;
        }
        else
        {
           // idleaudio.mute = true;
            Debug.Log("is it not working");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetTrigger("stag");
            AudioManager.instance.Play("beeBite");
        }
    }
}
