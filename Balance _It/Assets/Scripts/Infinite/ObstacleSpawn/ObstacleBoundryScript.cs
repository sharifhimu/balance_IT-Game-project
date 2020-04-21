using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBoundryScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "obsBoundry")
        {
            int x = col.GetComponent<ObstacleScript>().GetX();
            int y = col.GetComponent<ObstacleScript>().GetY();

            Debug.Log(x + "    " + y);
            GetComponentInParent<ObstacleSpawner>().AddObstacleIntheList(x, y);
        }
    }
}
