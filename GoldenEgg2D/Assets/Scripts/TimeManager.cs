using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private float timeRemaining = 10f;
    
    private LevelManager levelManager;

    void Start()
    {
        StartCoroutine(TimerCoroutine());
        levelManager=FindObjectOfType<LevelManager>();  
    }

    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            timeText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
            yield return new WaitForSeconds(1f); // Her saniye bir kez güncelle
            timeRemaining -= 1f;
        }
        levelManager.UpdateGameLevel();
    }
    private void DisplayTime()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + timeRemaining.ToString();

        }
    }
    

}
