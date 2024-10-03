using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

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
            yield return new WaitForSeconds(1f); // Her saniye bir kez güncelle
            timeRemaining -= 1f;
        }
        //EndGame();
    }
    private void DisplayTime()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + timeRemaining.ToString();

        }
    }
}
