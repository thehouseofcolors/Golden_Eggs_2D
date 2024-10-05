using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MainManager
{
    public TextMeshProUGUI timeText; // Zamaný gösterecek TextMeshPro öðesi
    private int remainingTime; // Geri sayým süresi
    private Coroutine timerCoroutine; // Timer coroutine'i

<<<<<<< HEAD
    public float timeRemaining = 10f;
    

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
        
    }
    public void StopTimer()
    {
        StopAllCoroutines(); // Stop all coroutines, including the timer.
        timeRemaining = 0; // Optionally reset the timer.
    }
    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining >= 0)
        {
            timeText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
            yield return new WaitForSeconds(1f); // Her saniye bir kez güncelle
            timeRemaining -= 1f;
        }StopTimer();

    }
    private void DisplayTime()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + timeRemaining.ToString();
=======
    

    public void Initialize()
    {
        remainingTime = 30; // Baþlangýç süresi
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
        if (status == GameStatus.playing && timerCoroutine == null) // Timer zaten çalýþmýyorsa baþlat
        {
            timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }

    protected void StopTimer()
    {
        if (status == GameStatus.pause && timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // Coroutine'i durdur
            timerCoroutine = null; // Coroutine referansýný sýfýrla
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0)
        {
            remainingTime -= 1; // Her saniye zamaný 1 azalt
            DisplayTime(); // Zamaný ekranda günceller
            yield return new WaitForSeconds(1f); // 1 saniye bekler
        }
>>>>>>> demo2

        remainingTime = 0; // Süre sýfýrlanýr
        DisplayTime(); // Zaman sýfýr olduðunda güncellenmiþ süreyi göster
        Debug.Log("Zaman doldu!"); // Zamanýn bittiði mesajý
        StopTimer(); // Timer bittiðinde durdur
    }
<<<<<<< HEAD
    

}
=======

    protected void DisplayTime()
    {
        timeText.text = "Time: " + remainingTime; // Zamaný yuvarlayarak göster
    }
}
>>>>>>> demo2
