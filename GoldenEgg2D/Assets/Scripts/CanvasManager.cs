using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject countdown;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject play;

    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private TextMeshProUGUI timerText; 
    [SerializeField] private TextMeshProUGUI countdownText; 

    [SerializeField] private GameSettings gameSettings;

    private float gameTime; 
    private int score;
    private int currentLevel;
    private bool isPlayingActive;

    private Coroutine countdownCoroutine;
    private Coroutine timerCoroutine;

    
    private static CanvasManager instance;
    public static CanvasManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("CanvasManager instance is null. Make sure there is a CanvasManager object in the scene.");
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("CanvasManager - Instance initialized");
        }
        else if (instance != this)
        {
            Debug.LogWarning("Another instance of CanvasManager already exists. Destroying this duplicate.");
            Destroy(gameObject); // Destroy duplicate instances
        }

    }


    private void OnEnable()
    {
        UI_Manager.Instance.CanvasStatusChanged += HandleCanvasChange;

    }
    private void OnDisable()
    {
        UI_Manager.Instance.CanvasStatusChanged -= HandleCanvasChange;
    }

    public void HandleCanvasChange(CanvasStatus status)
    {
        countdown.SetActive(false);
        play.SetActive(false);
        win.SetActive(false);
        gameOver.SetActive(false);

        switch (status)
        {
            case CanvasStatus.Countdown:
                countdown.gameObject.SetActive(true);
                CountdownProses();
                break;
            case CanvasStatus.Play:
                play.gameObject.SetActive(true);
                StartGame();
                break;
            case CanvasStatus.Win:
                win.gameObject.SetActive(true); break;
            case CanvasStatus.GameOver: 
                gameOver.gameObject.SetActive(true); break;

        }
    }

    
    private void Start()
    {
        HandleCanvasChange(CanvasStatus.Countdown);
        Debug.Log("uý start");
    }
    
    private void CountdownProses()
    {
        countdownText.gameObject.SetActive(true); 
        countdownCoroutine = StartCoroutine(Countdown());
        
    }
    
    private IEnumerator Countdown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Geri sayýmý güncelle
            yield return new WaitForSeconds(1); // 2 saniye bekle
        }

        countdownText.text = "Go!"; // "Go!" yaz
        yield return new WaitForSeconds(1); // 1 saniye bekle

        countdownText.gameObject.SetActive(false); // Geri sayým metnini gizle
        countdownCoroutine = null;
        HandleCanvasChange(CanvasStatus.Play); // Automatically transition to the Play canvas
  
    }
    
    public void StartGame()
    {
        gameTime = gameSettings.ResetTime();
        score=gameSettings.ResetScore();
        currentLevel = gameSettings.currentLevel;

        timerText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        UpdateScore(score);
        timerCoroutine = StartCoroutine(TimerCoroutine(gameTime));
        SpawnGameObjects.Instance.SpawnChicken();
    }
    
    private IEnumerator TimerCoroutine(float duration)
    {
        float timeRemaining = duration;

        while (timeRemaining >= 0)
        {
            // Kalan süreyi güncelleyin ve UI'ye yazdýrýn
            timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining);
            timeRemaining -= Time.deltaTime; // Geçen zamaný çýkar
            yield return null; // Bir sonraki frame'e geç
        }
        StopGame(); 


    }
    public void StopGame()
    {
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        timerCoroutine = null;
        play.SetActive(false);
        HandleCanvasChange(CanvasStatus.Win);
    }

    public void UpdateScore(int amount)
    {
        score += amount; // Puaný güncelle
        scoreText.text = $"Score: {score}"; // Puan metnini güncelle
    }


}


