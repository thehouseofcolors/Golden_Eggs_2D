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

    public event Action<int> OnScoreChanged; // Skor de�i�ti�inde tetiklenecek event


    private static UIControl instance;
    public static UIControl Instance {  get { return instance; } }
    private void Awake()
    {
        instance = this;
    }

    public void ChangeScore(int amount)
    {
        myGameData.CurrentScore += amount; // Skoru g�ncelle
        OnScoreChanged?.Invoke(myGameData.CurrentScore); // Olay� tetikle
    }

    private void OnEnable()
    {
        OnScoreChanged += UpdateScoreDisplay;
        OnScoreChanged += UpdateScoreDisplay;
    }
    private void OnDestroy()
    {
        OnScoreChanged -= UpdateScoreDisplay;
        OnScoreChanged -= UpdateScoreDisplay;
    }
    private void Start()
    {
        UpdateHealthDisplay(myGameData.CurrentHealth);
        UpdateScoreDisplay(myGameData.CurrentScore);
    }



    public void UpdateHealthDisplay(int score)
    {
        for (int i = 0; i < score; i++) { stars[i].sprite = starFilled; }
        for (int i = score; i < stars.Length; i++) { stars[i].sprite = starEmpty; }
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = "Score: " + score;
    }


}
