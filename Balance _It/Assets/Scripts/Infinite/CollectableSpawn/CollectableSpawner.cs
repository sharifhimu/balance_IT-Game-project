using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour {

    public static CollectableSpawner instance;

    [SerializeField] private GameObject[] collectables;

    [SerializeField] private List<GameObject> inactiveCollectables;

    private void Start()
    {
        instance = this;
        Init();
    }

    private void Init()
    {
        for(int i=0; i<collectables.Length; i++)
        {
            inactiveCollectables.Add(collectables[i]);
            collectables[i].SetActive(false);
        }
    }

    private void SpawnCollectable(Vector3 pos)
    {
        int indx = Random.Range(0, inactiveCollectables.Count);
        if (inactiveCollectables.Count > 0)
        {
            inactiveCollectables[indx].SetActive(true);
            inactiveCollectables[indx].transform.position = pos;
            inactiveCollectables.RemoveAt(indx);
        }
    }

    public void AddCollectableToList(GameObject go)
    {
        inactiveCollectables.Add(go);
    }
}
