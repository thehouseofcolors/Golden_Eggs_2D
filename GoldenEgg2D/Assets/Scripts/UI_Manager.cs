using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TextMeshProUGUI scoreText;
   

    
    [SerializeField] private Image[] stars; // Yýldýzlarý tutacak dizi
    [SerializeField] private Sprite starFilled; // Dolu yýldýz sprite'ý
    [SerializeField] private Sprite starEmpty; // Boþ yýldýz sprite'ý

    private int currentHealth; // Mevcut can sayýsý

    private void Start()
    {
        //currentHealth = stars.Length; // Baþlangýçta tüm yýldýz dolu
        UpdateHealthDisplay();
    }
    public void DisplayScore()
    {
        scoreText.text = "Score: " + gameSettings.currentScore;
    }
    public void SetHealth(int health)
    {
        currentHealth = health; // Caný güncelle
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < currentHealth)
            {
                stars[i].sprite = starFilled; // Dolu yýldýz
            }
            else
            {
                stars[i].sprite = starEmpty; // Boþ yýldýz
            }
        }
    }

}