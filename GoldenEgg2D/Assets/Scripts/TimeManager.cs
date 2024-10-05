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

    public int timeRemaining;

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
        remainingTime = 30;
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

        remainingTime = 0; // Süre sýfýrlanýr
        DisplayTime(); // Zaman sýfýr olduðunda güncellenmiþ süreyi göster
        Debug.Log("Zaman doldu!"); // Zamanýn bittiði mesajý
        StopTimer(); // Timer bittiðinde durdur
    }



    protected void DisplayTime()
    {
        timeText.text = "Time: " + remainingTime; // Zamaný yuvarlayarak göster
    }
}
