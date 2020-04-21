using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodscript : MonoBehaviour {
    [SerializeField] private bool Attack;

    [SerializeField] private GameObject log;
    [SerializeField] private GameObject warningSymbol;
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D triggerCollider;



    // Use this for initialization

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.SetParent(player);
            triggerCollider.enabled = false;
            warningSymbol.SetActive(true);
            Invoke("FallLog", 3);
            Attack = true;
        }
    }

    private void FallLog()
    {
        warningSymbol.SetActive(false);
        log.SetActive(true);
    }
}
