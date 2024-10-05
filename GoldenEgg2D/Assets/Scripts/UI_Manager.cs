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
    public CanvasGroup canvasGroup;  // CanvasGroup referans�

    // Canvas'� tamamen g�r�n�r yapar
    public void ShowCanvas()
    {
        canvasGroup.alpha = 1;        // �effafl��� kald�r�r (g�r�n�r yapar)
        canvasGroup.interactable = true;  // UI elemanlar�n�n etkile�imini a�ar
        canvasGroup.blocksRaycasts = true; // T�klamalar� kabul eder
    }

    // Canvas'� �effaf yapar (gizli)
    public void HideCanvas()
    {
        canvasGroup.alpha = 0;        // �effaf yapar (gizli)
        canvasGroup.interactable = false; // UI elemanlar�n�n etkile�imini kapat�r
        canvasGroup.blocksRaycasts = false; // T�klamalar� engeller
    }
}
