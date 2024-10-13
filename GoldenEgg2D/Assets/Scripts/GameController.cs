using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameData myGameData;

    private void Start()
    {
        // Oyun seviyesini baþlat
        myGameData.InitializeLevel();
        CanvasManager.Instance.ChangeCanvasStatus(CanvasStatus.Play);
    }

    

}
