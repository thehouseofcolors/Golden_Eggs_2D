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
    

    // Canvas'� tamamen g�r�n�r yapar
    public void ShowCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;        // �effafl��� kald�r�r (g�r�n�r yapar)
        canvasGroup.interactable = true;  // UI elemanlar�n�n etkile�imini a�ar
        canvasGroup.blocksRaycasts = true; // T�klamalar� kabul eder
    }

    // Canvas'� �effaf yapar (gizli)
    public void HideCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;        // �effaf yapar (gizli)
        canvasGroup.interactable = false; // UI elemanlar�n�n etkile�imini kapat�r
        canvasGroup.blocksRaycasts = false; // T�klamalar� engeller
    }
}
