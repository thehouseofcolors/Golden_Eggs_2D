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
    [SerializeField] private Image[] stars; // Y�ld�zlar� tutacak dizi
    [SerializeField] private Sprite starFilled; // Dolu y�ld�z sprite'�
    [SerializeField] private Sprite starEmpty; // Bo� y�ld�z sprite'�


    private int currentHealth;
    private void Start()
    {
        //currentHealth = stars.Length; // Ba�lang��ta t�m y�ld�z dolu
        UpdateHealthDisplay();
    }


    public void SetHealth(int health)
    {
        currentHealth = health; // Can� g�ncelle
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < currentHealth)
            {
                stars[i].sprite = starFilled; // Dolu y�ld�z
            }
            else
            {
                stars[i].sprite = starEmpty; // Bo� y�ld�z
            }
        }
    }
}