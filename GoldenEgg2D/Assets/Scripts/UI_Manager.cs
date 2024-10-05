using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CanvasGroup canvasGroup;  // CanvasGroup referansý

    // Canvas'ý tamamen görünür yapar
    public void ShowCanvas()
    {
        canvasGroup.alpha = 1;        // Þeffaflýðý kaldýrýr (görünür yapar)
        canvasGroup.interactable = true;  // UI elemanlarýnýn etkileþimini açar
        canvasGroup.blocksRaycasts = true; // Týklamalarý kabul eder
    }

    // Canvas'ý þeffaf yapar (gizli)
    public void HideCanvas()
    {
        canvasGroup.alpha = 0;        // Þeffaf yapar (gizli)
        canvasGroup.interactable = false; // UI elemanlarýnýn etkileþimini kapatýr
        canvasGroup.blocksRaycasts = false; // Týklamalarý engeller
    }
}
