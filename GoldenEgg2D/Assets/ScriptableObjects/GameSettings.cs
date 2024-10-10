using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int currentLevel = 1;

    public int ResetTime() => 10;
    public int ResetScore() => 0;
    public int NextLevel() { return currentLevel++; }

    

}
