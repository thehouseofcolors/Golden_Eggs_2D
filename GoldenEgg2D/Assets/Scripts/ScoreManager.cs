using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MainManager
{
    public TextMeshProUGUI scoreText;

    private int score;

    

    public void Initialize()
    {
        score = 0;
        DisplayScore();
    }

    protected int GetScore() => score;
    protected void UpdateScore(int scoreToAdd)
    { 
        score += scoreToAdd; 
        DisplayScore();
    }

    protected void DisplayScore()
    {
        scoreText.text = "Score: " + score;

    }

}
