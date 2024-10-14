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
    [SerializeField] private GameData gameData;

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


    private void OnEnable()
    {
        CanvasManager.Instance.CanvasStatusChanged += HandleTimer;
    }
    private void OnDestroy()
    {
        CanvasManager.Instance.CanvasStatusChanged -= HandleTimer;
    }

    private void HandleTimer(CanvasStatus status)
    {
        if (status==CanvasStatus.Play) { StartTimer();  }
        else { StopTimer(); }
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

        float timeRemaining = gameData.PlayTimeDuration;
        while (timeRemaining >= 0)
        {
            timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining);
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }
        StopTimer();
        CanvasManager.Instance.ChangeCanvasStatus(CanvasStatus.Win);    
    }

}
