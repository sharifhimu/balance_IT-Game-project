using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowScript : MonoBehaviour {

    public Transform target;
    public float yOffset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (target) {

            transform.position = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
        }

	}
}
