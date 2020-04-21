using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            // Kill our Player
            if (GameManagerArcade.Instance)
            {
                GameManagerArcade.Instance.KillPlayer();
            }
            else if (InfiniteGameManager.Instance)
            {
                InfiniteGameManager.Instance.KillPlayer();
            }

        }
    }
}
