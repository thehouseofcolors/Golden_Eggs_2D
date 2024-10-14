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

    [SerializeField] private Image[] stars; // Yýldýzlarý tutacak dizi
    [SerializeField] private Sprite starFilled; // Dolu yýldýz sprite'ý
    [SerializeField] private Sprite starEmpty; // Boþ yýldýz sprite'ý

    public event Action<int> OnScoreChanged; // Skor deðiþtiðinde tetiklenecek event
    public event Action<int> OnHealthChange;

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
        Debug.Log($"health changed {health}");
        myGameData.CurrentHealth -= health;
        OnHealthChange?.Invoke(myGameData.CurrentHealth);
    }
    public void ChangeScore(int amount)
    {
        Debug.Log("score changed");
        myGameData.CurrentScore += amount;
        OnScoreChanged?.Invoke(myGameData.CurrentScore); 
    }

    private void OnEnable()
    {
        OnScoreChanged += UpdateScoreDisplay;
<<<<<<< HEAD
        OnScoreChanged += UpdateScoreDisplay;
=======
        OnHealthChange += UpdateHealthDisplay;
>>>>>>> parent of 01aeadd (Revert "gameover eklendi")
    }
    private void OnDestroy()
    {
        OnScoreChanged -= UpdateScoreDisplay;
<<<<<<< HEAD
        OnScoreChanged -= UpdateScoreDisplay;
=======
        OnHealthChange -= UpdateHealthDisplay;
>>>>>>> parent of 01aeadd (Revert "gameover eklendi")
    }
    private void Start()
    {
        UpdateHealthDisplay(myGameData.CurrentHealth);
        UpdateScoreDisplay(myGameData.CurrentScore);
    }



<<<<<<< HEAD
    public void UpdateHealthDisplay(int score)
    {
        for (int i = 0; i < score; i++) { stars[i].sprite = starFilled; }
        for (int i = score; i < stars.Length; i++) { stars[i].sprite = starEmpty; }
=======
    public void UpdateHealthDisplay(int health)
    {
        if (health > 0)
        {
            for (int i = 0; i < health; i++) { stars[i].sprite = starFilled; }
            for (int i = health; i < stars.Length; i++) { stars[i].sprite = starEmpty; }
        }
        else if (health==0) 
        { 
            CanvasManager.Instance.ChangeCanvasStatus(CanvasStatus.GameOver); 
        }
        
>>>>>>> parent of 01aeadd (Revert "gameover eklendi")
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = "Score: " + score;
    }


}
