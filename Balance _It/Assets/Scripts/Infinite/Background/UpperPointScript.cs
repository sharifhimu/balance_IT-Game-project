using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPointScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ground")
        {
            GetComponentInParent<Background>().DisableBlock();
        }
    }
}
