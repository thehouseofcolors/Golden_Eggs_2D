using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameData gameData;

    private void Start()
    {
        // Oyun seviyesini baþlat
        gameData.InitializeLevel();
        CanvasManager.Instance.ChangeCanvasStatus(CanvasStatus.Play);
    }
    public event Action<int> LevelControl;

    public void LevelChanged(int level)
    {

    }

}
