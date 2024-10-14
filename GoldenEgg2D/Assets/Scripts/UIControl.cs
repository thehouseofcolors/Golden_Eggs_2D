using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class UIControl : MonoBehaviour
{

    public GameData myGameData;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Image[] stars; // Y�ld�zlar� tutacak dizi
    [SerializeField] private Sprite starFilled; // Dolu y�ld�z sprite'�
    [SerializeField] private Sprite starEmpty; // Bo� y�ld�z sprite'�

    public event Action<int> ScoreChanged; // Skor de�i�ti�inde tetiklenecek event
    public event Action<int> HealthChange;

    private static UIControl instance;
    public static UIControl Instance {  get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    public void ChangeHealth(int health)
    {
        myGameData.CurrentHealth -= health;
        HealthChange?.Invoke(myGameData.CurrentHealth);
    }
    public void ChangeScore(int amount)
    {
        myGameData.CurrentScore += amount;
        ScoreChanged?.Invoke(myGameData.CurrentScore); 
    }

    private void OnEnable()
    {
        ScoreChanged += UpdateScoreDisplay;
        HealthChange += UpdateHealthDisplay;
    }
    private void OnDestroy()
    {
        ScoreChanged -= UpdateScoreDisplay;
        HealthChange -= UpdateHealthDisplay;
    }
    private void Start()
    {
        UpdateHealthDisplay(myGameData.CurrentHealth);
        UpdateScoreDisplay(myGameData.CurrentScore);
    }


    public void UpdateHealthDisplay(int health)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = i < health ? starFilled : starEmpty;
        }

        if (health == 0)
        {
            CanvasManager.Instance.ChangeCanvasStatus(CanvasStatus.GameOver);
        }
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = $"Score: {score}";
    }


}
