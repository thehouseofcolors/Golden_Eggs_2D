using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    private void OnEnable()
    {
        GameController.Instance.GameStatusChanged += LevelControl;
    }
    private void OnDisable()
    {
        GameController.Instance.GameStatusChanged -= LevelControl;
    }
    private void LevelControl(GameStatus newStatus)
    {
        if (newStatus == GameStatus.Win) { GameData.Instance.AddLevel(); }
    }

}
