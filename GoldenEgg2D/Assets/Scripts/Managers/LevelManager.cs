using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct LevelData
{
    public int health;
    public int level;
    public int score;
    public int time;

    public LevelData(int _level, int _health, int _score, int _time)
    {
        level = _level;
        health = _health;
        score = _score;
        time = _time;
    }
    
}


public class LevelManager : Singleton<LevelManager>
{
    List<LevelData> LevelDatas = new List<LevelData>();
    public int CurrentLevel {get; private set;}

    public void Start()
    {
        NewLevel();
    }

    public void NewLevel(int amount = 1)
    {
        CurrentLevel += amount;
        EventBus.Publish(new ScoreChangedEvent(CurrentLevel));
    }

}
