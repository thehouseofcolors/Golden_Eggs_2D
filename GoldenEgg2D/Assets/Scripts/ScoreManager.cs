using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    private int score=0;


    public void UpdateScore(int add)
    {
        score += add;
        DisplayScore();
    }
    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;

    }


}
