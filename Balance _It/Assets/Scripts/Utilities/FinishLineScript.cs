using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "platform")
        {
            GameManagerArcade.Instance.GotoGameComplete();
        }
    }
}
