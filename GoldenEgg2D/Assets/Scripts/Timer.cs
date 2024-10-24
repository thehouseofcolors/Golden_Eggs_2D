using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;

    private Coroutine timerCoroutine;
    private static Timer instance;
    public static Timer Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Eðer birden fazla instance varsa mevcut nesneyi yok et
            return;
        }

        instance = this;
    }
    private void Start()
    {
        UpdateTimerDisplay(GameData.Instance.PlayTimeDuration);
    }

    private void OnEnable()
    {
        GameController.Instance.GameStatusChanged += HandleTimer;
    }
    private void OnDestroy()
    {
        GameController.Instance.GameStatusChanged -= HandleTimer;
    }

    private void HandleTimer(GameStatus status)
    {
        if (status == GameStatus.Play)
        {
            StartTimer();
        }
        
    }


    private void StartTimer()
    {
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }
    private void StopTimer()
    {
        if(timerCoroutine != null) {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
        
    }

    private IEnumerator TimerCoroutine()
    {

        float timeRemaining = GameData.Instance.PlayTimeDuration;
        while (timeRemaining >= 0)
        {
            UpdateTimerDisplay(timeRemaining);
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }
        EndGame();
    }
    private void UpdateTimerDisplay(float timeRemaining)
    {
        timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining);
    }
    private void EndGame()
    {
        StopTimer();
        GameController.Instance.SetGameStatus(GameStatus.Win);
        
    }
}
