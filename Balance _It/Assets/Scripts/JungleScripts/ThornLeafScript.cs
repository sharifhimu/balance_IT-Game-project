using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornLeafScript : MonoBehaviour {

    [SerializeField] private bool isAttacking;

    [SerializeField] private Animator leafMover, leafShaker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            leafMover.SetTrigger("attack");
            leafShaker.SetTrigger("attack");
            isAttacking = true;
        }
    }
}
