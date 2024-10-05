using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MainManager
{
    public TextMeshProUGUI scoreText;
<<<<<<< Updated upstream
    
    private int score;


    void Start()
    {
        score = 0;
    }

    public void UpdateScore(int add)
    {
        score += add;
        DisplayScore();
=======
    private int score = 0;



    protected int GetScore() => score;
    protected void UpdateScore(int scoreToAdd)
    { 
        score += scoreToAdd; 
        DisplayScore(); 
>>>>>>> Stashed changes
    }

    protected void DisplayScore()
    {
        scoreText.text = "Score: " + score;

    }

}
