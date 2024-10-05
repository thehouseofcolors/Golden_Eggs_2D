using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    public int playTime = 30;
    public int score = 0;
    public int currentLevel = 0;

    public int regularEggScore = 1;
    public int goldenEggScore = 10;



}
