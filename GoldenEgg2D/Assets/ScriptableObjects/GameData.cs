
using System.Collections.Generic;
using UnityEngine;


public enum CanvasStatus { Null, Play, Win, GameOver }
public enum GameStatus { Playing, Paused, Win, GameOver };  

[CreateAssetMenu(fileName ="GameData", menuName ="Game Data", order = 1)]
public class GameData: ScriptableObject
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private GameObject regularEggPrefab;
    [SerializeField] private GameObject goldenEggPrefab;

    [SerializeField]
    private Vector3[] _parentChickenPos;
    [SerializeField]
    private Vector3 _playerPos = new Vector3(0, -4, 0);
    [SerializeField]
    private int _playTimeDuration = 10;

    // Read-only properties

    public GameObject PlayerPrefab => playerPrefab;
    public GameObject ChickenPrefab => chickenPrefab;
    public GameObject RegularEggPrefab => regularEggPrefab;
    public GameObject GoldenEggPrefab => goldenEggPrefab;

    public Vector3 PlayerPos => _playerPos;
    public int PlayTimeDuration => _playTimeDuration;

    // Properties with both getter and setter
    [SerializeField]
    private int _currentLevel = 1;
    public int CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
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

    public Vector3 GetChickenPos(int index)
    {
        return _parentChickenPos[index];
    }
}
