using UnityEngine;


[CreateAssetMenu(fileName = "ObjectSettings", menuName = "Object Settings")]
public class ObjectSettings : ScriptableObject
{
    public int playTime = 30;
    public int score = 0;
    public int currentLevel = 0;

    public int regularEggScore = 1;
    public int goldenEggScore = 10;



}
