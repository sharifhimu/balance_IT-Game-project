using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField] public Transform upperPoint;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            GetComponentInParent<BackgroundScroller>().CreateNextGround();
        }
    }

    public void DisableBlock()
    {
        GetComponentInParent<BackgroundScroller>().AddToInactiveBlock(this);
        gameObject.SetActive(false);
    }
}
