using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour 
{

    private UI_Manager uiManager;
    private PlayingUIManager playingUIManager;
    
    private static GameControl _instance;
    public static GameControl Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameControl>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameControl>();
                    singletonObject.name = typeof(Main_Manager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }


    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
    }


    private void Start()
    {
        Debug.Log("gamecontrol stat");
        uiManager=FindObjectOfType<UI_Manager>();
        
        uiManager.ChangeGameStatus(GameStatus.Entry); // Oyunu baþlat
    }

    public void CompleteLevel()
    {
        playingUIManager.Win(); // Kazanma durumunu ayarla
    }

    public void FailLevel()
    {
        playingUIManager.GameOver(); // Oyun bitiþ durumunu ayarla
    }

    public void StartGame()
    {
        playingUIManager.StartTimer(30f); // 30 saniyelik zamanlayýcýyý baþlat
    }
}
