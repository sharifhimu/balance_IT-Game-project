using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] private Background[] backgrounds;

    [SerializeField] private List<Background> inactiveBackground;

    [SerializeField] private Background currentBackground;

    [SerializeField] private bool CreateBlock;

    public void Init()
    {
        CreateBlock = true;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (!backgrounds[i].gameObject.activeInHierarchy)
            {
                inactiveBackground.Add(backgrounds[i]);
            }
        }
    }

    public void CreateNextGround()
    {

        if(inactiveBackground.Count > 0 && CreateBlock == true)
        {
            CreateBlock = false;
            inactiveBackground[0].gameObject.SetActive(true);
            inactiveBackground[0].transform.position = currentBackground.upperPoint.position;
            currentBackground = inactiveBackground[0];
            inactiveBackground.RemoveAt(0);
        }
    }

    public void AddToInactiveBlock(Background block)
    {
        if (CreateBlock == false)
        {
            CreateBlock = true;
            inactiveBackground.Add(block);
        }
    }
}
