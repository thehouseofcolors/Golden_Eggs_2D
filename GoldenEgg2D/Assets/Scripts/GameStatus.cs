using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum GameState { Entry, Start, Playing, Paused}

public class GameStatus : MonoBehaviour
{
    public GameState currentState;
    private Manager manager;

    public Canvas Entry;
    public Canvas game;
    public Canvas endGame;
    

    public Button Play;
    public Button home;
    public Button start;


    private EggPoolManager EggPoolManager;
    private TimeManager timeManager;

    public GameObject Player;
    private List<GameObject> chickenList;
    private List<GameObject> eggList;
    

    void Start()
    {
        currentState = GameState.Entry;

        manager = FindObjectOfType<Manager>();
        EggPoolManager = FindObjectOfType<EggPoolManager>();
        timeManager = FindObjectOfType<TimeManager>();

        manager.SpawnChicken();
        manager.SpawnEgg();

        chickenList=manager.GetChickenList();
        eggList=manager.GetEggList();
    }

    public void StartingGame()
    {
        currentState=GameState.Playing;
        Player.SetActive(true);
        foreach(GameObject chicken in chickenList) { chicken.SetActive(true);}
        

    }
    public void StartGame()
    {
        if (timeManager == null)
        {
            timeManager = FindObjectOfType<TimeManager>();
        }
        if (EggPoolManager == null)
        {
            EggPoolManager = FindObjectOfType<EggPoolManager>();
        }

        if (timeManager == null || EggPoolManager == null)
        {
            Debug.LogError("TimeManager or EggPoolManager is not initialized");
            return;
        }

        endGame.enabled = false;
        game.enabled = true;
        
        currentState = GameState.Playing;
        
        foreach (GameObject chicken in manager.GetChickenList())
        {
            chicken.SetActive(true);  // Reactivate chickens
        }

        foreach (GameObject egg in manager.GetEggList())
        {
            egg.SetActive(false);  // Reset eggs
        }

        timeManager.StartTimer();

        EggPoolManager.StartDroping();
        

        Debug.Log("Game Started");
    }

    public void StopGame()
    {
        EggPoolManager.StopDroping();

        foreach (GameObject chicken in manager.GetChickenList())
        {
            chicken.SetActive(false);
        }

        foreach (GameObject egg in manager.GetEggList())
        {
            egg.SetActive(false);
        }
    }

    public void EndGame()
    {
        StopGame(); // This will deactivate game elements and stop egg dropping.
        endGame.enabled = true; // Show end game canvas.
        Debug.Log("Game Ended");
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.Start:
                break;

            case GameState.Playing:
                // Check if the game should end, like if the time has run out.
                if (timeManager.timeRemaining <= 0)
                {
                    EndGame();
                }
                break;

            case GameState.GameOver:
                break;
        }
    }


}
