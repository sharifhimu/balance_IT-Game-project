using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="playerInfo", menuName ="Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject {

    public int score;
    public int coins;
    public int stars;
    public int life;
    public int gem;

    public bool canMove;
    public string currentLevel;
}
