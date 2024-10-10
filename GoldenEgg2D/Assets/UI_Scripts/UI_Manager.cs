using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum CanvasStatus { Null, Countdown, Play, Win, GameOver }

public enum SceneStatus {Entry, MainMenu, Game }
public class UI_Manager : MonoBehaviour
{
    private static UI_Manager instance;
    public static UI_Manager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Another instance of UI_Manager already exists. Destroying this duplicate.");
            Destroy(gameObject); // Mevcut bir nesne varsa, yeni oluþturulan nesneyi yok et
        }
    }
    public delegate void SceneChangeEvent();
    public event SceneChangeEvent ChangeTheScene;
    private SceneStatus currentStatus;
    
    public event Action<CanvasStatus> CanvasStatusChanged;
    public CanvasStatus currentCanvasStatus;
    private void Start()
    {
        currentStatus = SceneStatus.Entry;
    }
    public void ChangeCanvasStatus(CanvasStatus newStatus)
    {
        if (currentCanvasStatus != newStatus)
        {
            currentCanvasStatus = newStatus;
            CanvasStatusChanged?.Invoke(newStatus); // Olayý tetikle
        }
    }
    public void ChangeSceneStatus(SceneStatus newStatus)
    {
        currentStatus = newStatus;
        HandleSceneChange(currentStatus);
        ChangeTheScene?.Invoke();
    }


    public void HandleSceneChange(SceneStatus status)
    {
        switch (status)
        {
            case SceneStatus.Entry: SceneManager.LoadScene("Entry"); break;
            case SceneStatus.MainMenu: SceneManager.LoadScene("MainMenu"); break;
            case SceneStatus.Game: SceneManager.LoadScene("Game"); ChangeCanvasStatus(CanvasStatus.Countdown); break;

            default: Debug.LogWarning("geçersiz sahne!"); break;

        }
    }

    public void OnEntryButtonClick()
    {
        ChangeSceneStatus(SceneStatus.MainMenu);
    }
    public void OnPlayButtonClick()
    {
        ChangeSceneStatus(SceneStatus.Game);
    }
    public void OnContinueButtonClick()
    {
        ChangeSceneStatus(SceneStatus.MainMenu);
    }
    public void OnTryAgainButtonClick()
    {
        ChangeSceneStatus(SceneStatus.Game);
    }
    public void OnSettingsButtonClick()
    {
        SceneManager.LoadScene("Settings");
    }
    public void OnLevelsButtonClick()
    {
        SceneManager.LoadScene("Levels");
    }
}
