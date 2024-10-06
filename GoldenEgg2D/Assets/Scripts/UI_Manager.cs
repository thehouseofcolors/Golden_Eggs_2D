using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    private CanvasGroup Entry;
    private CanvasGroup Play;
    private CanvasGroup Pause;

    [SerializeField] private GameObject entry;

    [SerializeField] private GameObject play;

    [SerializeField] private GameObject pause;


    private void Start()
    {
        Entry= entry.GetComponent<CanvasGroup>();
        Play=play.GetComponent <CanvasGroup>();
        Pause=pause.GetComponent <CanvasGroup>();

    }
    

    private void OnEnable()
    {
        Main_Manager.Instance.gameStatusChanged += UpdateUI;
    }
    private void OnDestroy()
    {
        Main_Manager.Instance.gameStatusChanged -= UpdateUI;
    }

    public void UpdateUI(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Entry:
                ShowCanvas(Entry);
                HideCanvas(Play);
                HideCanvas(Pause);
                break;
            case GameStatus.Playing:
                ShowCanvas(Play);
                HideCanvas(Entry);
                HideCanvas(Pause);
                break;
            case GameStatus.Paused:
                ShowCanvas(Pause);
                HideCanvas(Play);
                HideCanvas(Entry);
                break;
        }
    }
    

    // Canvas'ý tamamen görünür yapar
    public void ShowCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;        // Þeffaflýðý kaldýrýr (görünür yapar)
        canvasGroup.interactable = true;  // UI elemanlarýnýn etkileþimini açar
        canvasGroup.blocksRaycasts = true; // Týklamalarý kabul eder
    }

    // Canvas'ý þeffaf yapar (gizli)
    public void HideCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;        // Þeffaf yapar (gizli)
        canvasGroup.interactable = false; // UI elemanlarýnýn etkileþimini kapatýr
        canvasGroup.blocksRaycasts = false; // Týklamalarý engeller
    }
}
