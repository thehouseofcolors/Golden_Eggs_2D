using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class UIControl : MonoBehaviour
{

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
        UpdateHealthDisplay(GameData.Instance.CurrentHealth);
        UpdateScoreDisplay(GameData.Instance.CurrentScore);
    }

    public void ChangeHealth(int health)
    {
        GameData.Instance.CurrentHealth -= health;
        HealthChange?.Invoke(GameData.Instance.CurrentHealth);
    }
    public void ChangeScore(int amount)
    {
        GameData.Instance.CurrentScore += amount;
        ScoreChanged?.Invoke(GameData.Instance.CurrentScore);
    }
    public void UpdateHealthDisplay(int health)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = i < health ? starFilled : starEmpty;
        }

        if (health == 0)
        {
            GameController.Instance.SetGameStatus(GameStatus.GameOver);
        }
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = $"Score: {score}";
    }


}
