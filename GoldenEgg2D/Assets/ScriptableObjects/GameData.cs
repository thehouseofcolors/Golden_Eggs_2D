
using System.Collections.Generic;
using UnityEngine;


public enum GameStatus { Play, Pause, Win, GameOver };  

[CreateAssetMenu(fileName ="GameData", menuName ="Game Data", order = 1)]
public class GameData: ScriptableObject
{
    private static GameData instance;
    public static GameData Instance
    {
        get
        {
            // Check if the instance is null and load the ScriptableObject from Resources
            if (instance == null)
            {
                instance = Resources.Load<GameData>("MyGameData");
                if (instance == null)
                {
                    Debug.LogError("GameData instance not found! Make sure to create a GameData asset in the Resources folder.");
                }
            }
            return instance;
        }
    }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private GameObject regularEggPrefab;
    [SerializeField] private GameObject goldenEggPrefab;

    [SerializeField]
    private Vector3 _parentChickenPos = new Vector3(0, 4, 5);
    [SerializeField]
    private Vector3 _playerPos = new Vector3(0, -4, 0);
    
    // Read-only properties

    public GameObject PlayerPrefab => playerPrefab;
    public GameObject ChickenPrefab => chickenPrefab;
    public GameObject RegularEggPrefab => regularEggPrefab;
    public GameObject GoldenEggPrefab => goldenEggPrefab;
    public Vector3 PlayerPos => _playerPos;
    public Vector3 ChickenPos  => _parentChickenPos;
    

    // Properties with both getter and setter
    [SerializeField]
    private int _playTimeDuration = 30;
    public int PlayTimeDuration => _playTimeDuration;

    private GameStatus _status = GameStatus.Pause;
    public GameStatus CurrentGameStatus
    {
        get { return _status; }
        set { _status = value; }
    }


    [SerializeField]
    private int _currentLevel = 1;
    public int CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }
    public int AddLevel(int level)
    {
        return _currentLevel += level;

    }

    [SerializeField]
    private int _currentScore = 0;
    public int CurrentScore
    {
        get { return _currentScore; }
        set { _currentScore = value; }
    }

    [SerializeField]
    private int _currentHealth = 3;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public void InitializeLevel()
    {
        CurrentHealth=3; CurrentScore=0;
    }

    
}
