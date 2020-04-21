using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRippleCreator : MonoBehaviour {

    public GameObject ripple;
    public Transform parent;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Input.mousePosition;
            GameObject go = Instantiate(ripple, pos, ripple.transform.rotation);
            go.transform.SetParent(parent);
        }
	}
}
