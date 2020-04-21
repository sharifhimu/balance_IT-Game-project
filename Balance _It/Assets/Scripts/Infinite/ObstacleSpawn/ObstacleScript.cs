using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    [SerializeField] private int x, y;

    [SerializeField] bool isBush;
    [SerializeField] bool isleft;

    public void SetIndex(int i, int j)
    {
        x = i;
        y = j;
    }

    Transform platform;

    private void Update()
    {
        if(platform == null)
        {
            platform = GameObject.FindGameObjectWithTag("platform").transform;
        }
        else
        {
            if(transform.position.y - platform.position.y < -3f)
            {
                if(isBush)
                {
                    ObstacleSpawner.instance.AddBushToList(isleft, gameObject);
                }
                else
                    ObstacleSpawner.instance.AddObstacleIntheList(x, y);
                gameObject.SetActive(false);
            }
        }
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public void InitObstacle()
    {
       
    }


    
}
