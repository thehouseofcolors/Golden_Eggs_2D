using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Singleton �rne�i
    private static MainManager _instance;

    // Singleton eri�imi
    public static MainManager Instance
    {
        get
        {
            // E�er instance mevcut de�ilse, yeni bir GameObject olu�tur
            if (_instance == null)
            {
                GameObject obj = new GameObject("MainManager");
                _instance = obj.AddComponent<MainManager>();
            }
            return _instance;
        }
    }
    public enum GameStatus { entry, playing, pause }
    protected GameStatus status;

    protected GameManager gameManager;
    protected ScoreManager scoreManager;
    protected TimeManager timeManager;

    protected GameObject Player;
    private GameObject chickenPrefab;
    private GameObject regularEggPrefab;
    private GameObject goldenEggPrefab;

    protected List<GameObject> gameObjects;
    protected List<GameObject> chickenList;
    protected List<GameObject> eggList;
    
    private void Awake()
    {
        // E�er ba�ka bir instance varsa yok et
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Singleton �rne�ini sakla
        _instance = this;
        DontDestroyOnLoad(gameObject); // Oyun sahneleri aras�nda kal�c� olmas�n� sa�la

        InitializeManagers();
        status = GameStatus.entry; // Ba�lang�� durumu
    }

    private void InitializeManagers()
    {
        gameManager = gameObject.AddComponent<GameManager>();
        scoreManager = gameObject.AddComponent<ScoreManager>();
        timeManager = gameObject.AddComponent<TimeManager>();

        // Initialization calls
        timeManager.Initialize();
        scoreManager.Initialize();
    }

    public virtual void OnStartButtonPressed()
    {
        status = GameStatus.playing; // Oyunu ba�lat
    }

    public virtual void OnStopButtonPressed()
    {
        status = GameStatus.pause; // Oyunu duraklat
    }

    void Update()
    {
        // Oyunun durumuna g�re i�lem yap
        if (status == GameStatus.playing)
        {
            // Oyun devam ediyor
        }
    }
}
