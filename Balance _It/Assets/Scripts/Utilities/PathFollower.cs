using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    [SerializeField] Transform follower;
    [SerializeField] Transform pathHolder;
    [SerializeField] List<PathPoint> path;

    [SerializeField] int currentPathIndx;
    [SerializeField] float speed, waitTimer;
    [SerializeField] bool waitInPosition;

    // Use this for initialization
    void Start () {
        follower = transform.GetChild(0);
        pathHolder = transform.GetChild(1);

        PathPoint[] pt = pathHolder.GetComponentsInChildren<PathPoint>();
        
        for(int i=0; i<pt.Length; i++)
        {
            if(pt[i].GetComponent<PathPoint>())
                path.Add(pt[i]);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        follower.position = Vector3.MoveTowards(follower.position, path[currentPathIndx].transform.position, speed * Time.deltaTime);
        if(Vector3.Distance(follower.position,path[currentPathIndx].transform.position) <= .01f)
        {

            if (path[currentPathIndx].willFlip)
            {
                //Debug.Log("should flip");
                follower.localScale = new Vector3(follower.localScale.x * -1, follower.localScale.y, follower.localScale.z);

            }
                
                currentPathIndx++;

            if (currentPathIndx == path.Count)
                currentPathIndx = 0;
        }
	}

}