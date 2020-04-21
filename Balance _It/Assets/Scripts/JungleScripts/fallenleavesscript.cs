using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallenleavesscript : MonoBehaviour {

    [SerializeField] private Transform[] spawnpoint;

    private float timer;
    [SerializeField] private float delaytime;
    [SerializeField] private bool isgameover;

    private int numberoffallenleaves;
    [SerializeField] private int maxleaves;
    [SerializeField] private GameObject leaf;
    // Use this for initialization
    void Start () {
        timer = delaytime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        fallenleaves();
	}

    private void fallenleaves()
    {

        if (!isgameover)
        {

            timer -= Time.deltaTime;

            if (timer < 0)
            {
                numberoffallenleaves++;
                delaytime = Random.Range(.2f,5f);
                timer = delaytime;

                int indx = Random.Range(0, spawnpoint.Length);
                GameObject go = Instantiate(leaf, spawnpoint[indx].position, spawnpoint[indx].rotation);
                Destroy(go, 10);
            }
        }
    }

    

}
