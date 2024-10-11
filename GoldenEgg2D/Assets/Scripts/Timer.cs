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
    [SerializeField] private GameSettings gameSettings;

    private Coroutine timerCoroutine;
    private static Timer timer;
    public static Timer Instance { get { return timer; } }

    private void Awake()
    {
        Debug.Log("timer awakw");
        timer = this;
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
        Debug.Log("handle timer start");
    }


    public void StartTimer()
    {
        Debug.Log("timer start");
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }
    public void StopTimer()
    {
        StopCoroutine(timerCoroutine);
        timerCoroutine = null;
    }

    private IEnumerator TimerCoroutine()
    {
        float timeRemaining = gameSettings.ResetTime();
        while (timeRemaining > 0)
        {
            Debug.Log("time");
            timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining);
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }
        StopTimer();
    }

}
