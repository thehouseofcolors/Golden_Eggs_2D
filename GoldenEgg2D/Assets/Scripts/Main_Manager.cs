using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus { Entry, Playing, Paused}

public class Main_Manager : MonoBehaviour
{
    private static Main_Manager _instance;
    public static Main_Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Main_Manager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Main_Manager>();
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

    public event Action<GameStatus> gameStatusChanged;

    public GameStatus currentStatus = GameStatus.Playing;

    private void Start()
    {
        ChangeGameStatus(GameStatus.Entry);
    }

    
    public void ChangeGameStatus(GameStatus newStatus)
    {
        if(currentStatus != newStatus)
        {
            currentStatus = newStatus;
            gameStatusChanged?.Invoke(currentStatus);

        }
    }

    public void StartGame()
    {
        ChangeGameStatus(GameStatus.Playing);
    }
}
