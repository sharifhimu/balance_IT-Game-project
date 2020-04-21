using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="level_info", menuName ="ScriptableObject/LevelInfo")]
public class LevelInfos : ScriptableObject {
    
    public string levelName;
    public int levelIndex;
    public int pointsNeedToUnlock;
    public Sprite themeImage;
    

}
