using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;



public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject play;

   
    public bool isGameActive;

    private static CanvasManager instance;
    public static CanvasManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Eðer birden fazla instance varsa mevcut nesneyi yok et
            return;
        }

        instance = this;
    }
    private void OnEnable()
    {
        GameController.Instance.GameStatusChanged += HandleTheGame;

    }
   

    
    private void OnDestroy()
    {
        GameController.Instance.GameStatusChanged -= HandleTheGame;
    }

    private void HandleTheGame(GameStatus status)
    {
        Debug.Log("handle the game called");

        play.SetActive(false);
        win.SetActive(false);
        gameOver.SetActive(false);

        switch (status)
        {
            case GameStatus.Play:
                play.gameObject.SetActive(true);
                isGameActive = true;
                break;
            case GameStatus.Win:
                win.gameObject.SetActive(true);

                isGameActive = false;
                break;
            case GameStatus.GameOver:
                gameOver.gameObject.SetActive(true);
                isGameActive = false;
                break;

        }
    }


}


