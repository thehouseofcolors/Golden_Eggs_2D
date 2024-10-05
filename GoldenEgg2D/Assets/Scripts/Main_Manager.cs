using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus { Entry, Playing, Paused}
public class Main_Manager : MonoBehaviour
{
    public GameStatus currentStatus = GameStatus.Entry;

    public delegate void OnGameStatusChanged(GameStatus newStatus);
    public event OnGameStatusChanged gameStatusChanged;

    private void Start()
    {


    }
    public void ChangeGameStatus(GameStatus newStatus)
    {
        if(currentStatus != newStatus)
        {
            currentStatus = newStatus;
            gameStatusChanged?.Invoke(currentStatus);

        }
    }
    public void SetToHome() => ChangeGameStatus(GameStatus.Entry);
    public void StartGame() => ChangeGameStatus(GameStatus.Playing);
    public void PauseGame() => ChangeGameStatus(GameStatus.Paused);
    

}
