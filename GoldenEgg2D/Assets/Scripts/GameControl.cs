using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour 
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    private int currentScore;
    private int currentTime;

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


    private void OnEnable()
    {
        Main_Manager.Instance.gameStatusChanged += GameSettingsControl;
    }
    private void OnDestroy()
    {
        Main_Manager.Instance.gameStatusChanged -= GameSettingsControl;
    }
    

    public void GameSettingsControl(GameStatus status)
    {
        if (Main_Manager.Instance.currentStatus == GameStatus.Entry)
        {
            currentScore = settings.ResetScore();
            currentTime = settings.ResetTime();
            UpdateScoreUI();
            UpdateTimeUI();
        }
        if (Main_Manager.Instance.currentStatus == GameStatus.Playing)
        {
            StartTimer();
        }
    }

    

    private IEnumerator TimerRoutine()
    {
        while (Main_Manager.Instance.currentStatus == GameStatus.Playing)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimeUI();

            if (currentTime <= 0)
            {
                Main_Manager.Instance.ChangeGameStatus(GameStatus.Paused);
            }
        }
    }

    public void StartTimer()
    {
        StopAllCoroutines(); // Her ihtimale karþý önceki Coroutine'leri durdur
        StartCoroutine(TimerRoutine());
    }
    public void AddScore(int addToScore)
    {
        
        if(Main_Manager.Instance.currentStatus==GameStatus.Playing)
        {
            currentScore += addToScore;
            UpdateScoreUI();
        }
    }
    

    private void UpdateScoreUI()
    {
        
        scoreText.text = "Score: " + currentScore.ToString();
    }
    private void UpdateTimeUI()
    {
        timeText.text = "Time: " + currentTime.ToString();
    }
}
