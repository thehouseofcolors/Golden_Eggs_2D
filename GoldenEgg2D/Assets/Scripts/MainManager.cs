using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Singleton örneði
    private static MainManager _instance;

    // Singleton eriþimi
    public static MainManager Instance
    {
        get
        {
            // Eðer instance mevcut deðilse, yeni bir GameObject oluþtur
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
        // Eðer baþka bir instance varsa yok et
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Singleton örneðini sakla
        _instance = this;
        DontDestroyOnLoad(gameObject); // Oyun sahneleri arasýnda kalýcý olmasýný saðla

        InitializeManagers();
        status = GameStatus.entry; // Baþlangýç durumu
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
        status = GameStatus.playing; // Oyunu baþlat
    }

    public virtual void OnStopButtonPressed()
    {
        status = GameStatus.pause; // Oyunu duraklat
    }

    void Update()
    {
        // Oyunun durumuna göre iþlem yap
        if (status == GameStatus.playing)
        {
            // Oyun devam ediyor
        }
    }
}
