using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

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

        }
    }
    

}
