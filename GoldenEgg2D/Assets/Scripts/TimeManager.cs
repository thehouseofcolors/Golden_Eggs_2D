using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MainManager
{
    public TextMeshProUGUI timeText; // Zaman� g�sterecek TextMeshPro ��esi
    private int remainingTime; // Geri say�m s�resi
    private Coroutine timerCoroutine; // Timer coroutine'i

    public int timeRemaining;

    public void Initialize()
    {
        remainingTime = 30; // Ba�lang�� s�resi
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
        if (status == GameStatus.playing && timerCoroutine == null) // Timer zaten �al��m�yorsa ba�lat
        {
            timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }

    protected void StopTimer()
    {
        if (status == GameStatus.pause && timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); // Coroutine'i durdur
            timerCoroutine = null; // Coroutine referans�n� s�f�rla
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0)
        {
            remainingTime -= 1; // Her saniye zaman� 1 azalt
            DisplayTime(); // Zaman� ekranda g�nceller
            yield return new WaitForSeconds(1f); // 1 saniye bekler
        }

        remainingTime = 0; // S�re s�f�rlan�r
        DisplayTime(); // Zaman s�f�r oldu�unda g�ncellenmi� s�reyi g�ster
        Debug.Log("Zaman doldu!"); // Zaman�n bitti�i mesaj�
        StopTimer(); // Timer bitti�inde durdur
    }



    protected void DisplayTime()
    {
        timeText.text = "Time: " + remainingTime; // Zaman� yuvarlayarak g�ster
    }
}
