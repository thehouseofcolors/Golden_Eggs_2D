using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public enum GameStatus { entry, playing, pause}
    protected GameStatus status;
    private GameManager gameManager;
    private ScoreManager scoreManager;
    private TimeManager timeManager;

    protected GameObject Player;
    private GameObject chickenPrefab;
    private GameObject regularEggPrefab;
    private GameObject goldenEggPrefab;


    protected List<GameObject> gameObjects;
    protected List<GameObject> chickenList;
    protected List<GameObject> eggList;

    public virtual void OnStartButtonPressed()
    {
    }

    public virtual void OnStopButtonPressed()
    {
    }

    void Start()
    {
        gameManager = new GameManager();
        scoreManager = new ScoreManager();
        timeManager = new TimeManager();

        timeManager.Initialize();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
