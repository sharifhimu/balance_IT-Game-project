using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private float ObstacleCreateTimer, ObstacleCreateDelay, leftObstacleTimer, rightObstacleTimer, leftObstacleDelay, rightObstacleDelay;
    [SerializeField] private Transform spawnPoint, leftSidePoint, rightSidePoint;


    [SerializeField] private InfObstacles[] obstacles;
    [SerializeField] private InfObstacles[] InactiveObstacles;

    [SerializeField] private GameObject[] leftObstacle, rightObstacle;
    [SerializeField] private List<GameObject> leftInactiveObstacle, rightInactiveObstacle;

    public int currentLevelIndex;
    InfObstacles lst;

    public static ObstacleSpawner instance;

    public void Init()
    {
        ObstacleCreateDelay = Random.Range(3.0f, 5.0f);
        ObstacleCreateTimer = ObstacleCreateDelay;

        leftObstacleDelay = Random.Range(3.0f, 10.0f);
        rightObstacleDelay = Random.Range(3.0f, 10.0f);

        leftObstacleTimer = leftObstacleDelay;
        rightObstacleTimer = rightObstacleDelay;
        instance = this;
        for(int i=0; i<obstacles.Length; i++)
        {
            
            for (int j = 0; j < obstacles[i].obstacle.Count; j++)
            {
                obstacles[i].obstacle[j].GetComponent<ObstacleScript>().SetIndex(i, j);
                if (!obstacles[i].obstacle[j].activeInHierarchy)
                {
                    InactiveObstacles[i].obstacle.Add(obstacles[i].obstacle[j]);
                }
            }
        }

        for (int i = 0; i < leftObstacle.Length; i++)
        {
            leftObstacle[i].SetActive(false);
            leftInactiveObstacle.Add(leftObstacle[i]);
        }
        for (int i = 0; i < rightObstacle.Length; i++)
        {
            rightObstacle[i].SetActive(false);
            rightInactiveObstacle.Add(rightObstacle[i]);
        }
    }

    public void CreateObstacle()
    {
        if(ObstacleCreateTimer >-2.0f)
            ObstacleCreateTimer -= Time.deltaTime;

        if(ObstacleCreateTimer <= 0.0f)
        {
            // Spawn Obstacle
            ObstacleCreateDelay = Random.Range(3.0f, 5.0f);
            ObstacleCreateTimer = ObstacleCreateDelay;
            int indx = Random.Range(0, InactiveObstacles[currentLevelIndex].obstacle.Count);
            Debug.Log("Spawning: " + currentLevelIndex + "    " + indx);
            InactiveObstacles[currentLevelIndex].obstacle[indx].SetActive(true);
            InactiveObstacles[currentLevelIndex].obstacle[indx].transform.position = spawnPoint.position;
            InactiveObstacles[currentLevelIndex].obstacle.RemoveAt(indx);

        }
    }

    public void CreateSideObstacle()
    {
        if (leftObstacleTimer > -2.0f)
            leftObstacleTimer -= Time.deltaTime;

        if (rightObstacleTimer > -2.0f)
            rightObstacleTimer -= Time.deltaTime;

        if (leftObstacleTimer <= 0.0f)
        {
            // Spawn Obstacle
            leftObstacleDelay = Random.Range(3.0f, 10.0f);
            leftObstacleTimer = leftObstacleDelay;
            if (leftInactiveObstacle.Count > 0)
            {
                leftInactiveObstacle[0].SetActive(true);
                leftInactiveObstacle[0].transform.position = leftSidePoint.position;
                leftInactiveObstacle.RemoveAt(0);
            }
        }

        if (rightObstacleTimer <= 0.0f)
        {
            // Spawn Obstacle
            rightObstacleDelay = Random.Range(3.0f, 10.0f);
            rightObstacleTimer = rightObstacleDelay;
            if (rightInactiveObstacle.Count > 0)
            {
                rightInactiveObstacle[0].SetActive(true);
                rightInactiveObstacle[0].transform.position = rightSidePoint.position;
                rightInactiveObstacle.RemoveAt(0);
            }

        }
    }

    public void AddObstacleIntheList(int i, int j)
    {
        InactiveObstacles[i].obstacle.Add(obstacles[i].obstacle[j]);
    }

    public void AddBushToList(bool left, GameObject gameObject)
    {
        if (left)
            leftInactiveObstacle.Add(gameObject);
        else
            rightInactiveObstacle.Add(gameObject);
    }

}

[System.Serializable]
class InfObstacles
{
    [SerializeField] public List<GameObject> obstacle;
}
