using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="item", menuName ="ScriptableObject/InventoryItem")]
public class InventoryItems : ScriptableObject {
    public Items[] items;

}

[System.Serializable]
public class Items
{
    public string name;
    public int id;
    public string GPGID;
    public Sprite sprite;
    public int coinsNeededToUnlock;

}
