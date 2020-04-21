using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject ground;
    [SerializeField] private float maxAngle, minAngle;

    public void ControlPlatform()
    {
            MovePlatformUpward();
            RotateBase();
    }

    private void RotateBase()
    {
        float hor = CnControls.CnInputManager.GetAxis("Horizontal");

      //  float hor1 = Input.acceleration.x;

        ground.transform.Rotate(0, 0, -hor * rotationSpeed * Time.deltaTime);
        //ground.transform.Rotate(0, 0, -hor1 * 50 * Time.deltaTime);
        if (ground.transform.eulerAngles.z > 10 && ground.transform.eulerAngles.z < 20)
            ground.transform.eulerAngles = new Vector3(ground.transform.eulerAngles.x, ground.transform.eulerAngles.y, 10);
        else if (ground.transform.eulerAngles.z < 350 && ground.transform.eulerAngles.z > 340)
        {

            ground.transform.eulerAngles = new Vector3(ground.transform.eulerAngles.x, ground.transform.eulerAngles.y, 350);
        }
    }

    private void MovePlatformUpward()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
}
