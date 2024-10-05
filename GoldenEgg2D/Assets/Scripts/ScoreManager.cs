using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MainManager
{
    public TextMeshProUGUI scoreText;
<<<<<<< HEAD
    
    private int score=0;
=======

    private int score;
>>>>>>> demo2

    

<<<<<<< HEAD
    public void UpdateScore(int add)
    {
        score += add;
=======
    public void Initialize()
    {
        score = 0;
>>>>>>> demo2
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
