using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Playing, GameOver }

public class LevelManager : MonoBehaviour
{

    public Canvas game;
    public Canvas endGame;

    private GameState currentState;

    private Manager manager;

    private EggPoolManager EggPoolManager;
    

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        manager=FindObjectOfType<Manager>();
        EggPoolManager=FindObjectOfType<EggPoolManager>();

    }



    public void StartGame()
    {
        currentState=GameState.Playing;
        game.enabled = true;
        endGame.enabled=false;
    }

    public void UpdateGameLevel()
    {
        currentState = GameState.GameOver;

        manager.StopGame();
        
        game.enabled=false;
        endGame.enabled=true;
        


    }
}
