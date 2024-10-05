using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MainManager
{
    public TextMeshProUGUI timeText;
    private int remainingTime;
    private Coroutine timerCoroutine;

<<<<<<< Updated upstream
    private float timeRemaining = 30f;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            timeText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
            yield return new WaitForSeconds(1f); // Her saniye bir kez g�ncelle
            timeRemaining -= 1f;
        }
        //EndGame();
    }
    private void DisplayTime()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + timeRemaining.ToString();

=======
    public void Initialize()
    {
        remainingTime = 30;
    }
    public override void OnStartButtonPressed()
    {
        StartTimer();
    }

    public override void OnStopButtonPressed()
    {
        StopTimer();
    }
    protected void StartTimer()
    {
        if (status==GameStatus.playing)
        {
            timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }

    protected void StopTimer()
    {
        if (status==GameStatus.pause)
        {
            if (timerCoroutine != null)
            {
                StopCoroutine(timerCoroutine);  // Coroutine'i durdurur
            }
        }
    }
    private IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0)
        {
            remainingTime -= 1; // Her saniye zaman� 1 azalt
            DisplayTime();  // Zaman� ekranda g�nceller
            yield return new WaitForSeconds(1f);  // 1 saniye bekler
>>>>>>> Stashed changes
        }

        remainingTime = 0;
        DisplayTime();  // Zaman s�f�r oldu�unda g�ncellenmi� s�reyi g�ster
        StopTimer();  // Timer bitti�inde durdur
        Debug.Log("Zaman doldu!");  // Zaman�n bitti�i mesaj�
    }
<<<<<<< Updated upstream
=======
    protected void DisplayTime()
    {
        timeText.text = "Time: " + remainingTime;

    }


>>>>>>> Stashed changes
}
