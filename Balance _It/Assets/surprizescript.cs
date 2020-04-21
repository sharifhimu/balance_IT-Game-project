using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surprizescript : MonoBehaviour {

   [SerializeField] private bool surprize;
    [SerializeField] private GameObject symbol;
    [SerializeField] private Animator start;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            symbol.SetActive(true);
            start.SetTrigger("surprize_symbol");
            surprize = true;
        }
    }



}
