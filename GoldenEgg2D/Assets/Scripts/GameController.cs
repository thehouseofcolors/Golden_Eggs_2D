using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI scoreText;



    private int currentScore;
    private int currentHealth;
    private int currentLevel;

    private void OnEnable()
    {
        
    }

    public void InitializeLevel()
    {
        currentScore = 0;
        gameData.CurrentScore = currentScore;
        currentHealth = gameData.PlayerHealthStart;
        currentLevel = gameData.CurrentLevel;
    }
    public void DisplayScore()
    {
        scoreText.text ="Score: "+ currentScore.ToString();
    }

    

}
