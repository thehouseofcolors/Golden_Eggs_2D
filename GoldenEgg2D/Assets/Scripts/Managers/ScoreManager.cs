using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct ScoreChangedEvent
{
    public int NewScore;

    public ScoreChangedEvent(int newScore)
    {
        NewScore = newScore;
    }
}
public class ScoreManager : Singleton<ScoreManager>
{
    
    public static int Score{get; private set;}
    
    public void AddScore(int amount = 1)
    {
        Score += amount;
        EventBus.Publish(new ScoreChangedEvent(Score));
    }


}
