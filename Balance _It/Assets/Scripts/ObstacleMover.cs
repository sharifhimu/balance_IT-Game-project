using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

	private float speed;
    public float offset;
    private void FixedUpdate()
    {
        if(GameManager.Instance.IsGameStarted())
            transform.Translate(0, -speed * Time.deltaTime*offset, 0);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Edge")
        {
            gameObject.SetActive(false);
            GameManager.Instance.IncreaseScore();
        }
    }
}
