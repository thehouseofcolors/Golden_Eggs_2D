using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public enum CanvasStatus { Null, Play, Win, GameOver }

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject play;


    [SerializeField] private GameSettings gameSettings;

    public bool isGameActive;


    private static CanvasManager instance;
    public static CanvasManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        Debug.Log("canvas awakw");
        instance = this;
    }
    public event Action<CanvasStatus> CanvasStatusChanged;
    public CanvasStatus currentCanvasStatus;

    private void Start()
    {
        Debug.Log("canvas start");
        ChangeCanvasStatus(CanvasStatus.Play);
    }
    public void ChangeCanvasStatus(CanvasStatus newStatus)
    {
        if (currentCanvasStatus != newStatus)
        {
            currentCanvasStatus = newStatus;
            CanvasStatusChanged?.Invoke(newStatus); // Olayý tetikle
            Debug.Log("olay tetiklendi");
        }
    }

    private void OnEnable()
    {
        Debug.Log("canvas onenable");
        CanvasStatusChanged += HandleCanvasChange;

    }
    private void OnDestroy()
    {
        CanvasStatusChanged -= HandleCanvasChange;
    }
    
    public void HandleCanvasChange(CanvasStatus status)
    {

        play.SetActive(false);
        win.SetActive(false);
        gameOver.SetActive(false);

        switch (status)
        {
            case CanvasStatus.Play:
                play.gameObject.SetActive(true);isGameActive = true;
                break;
            case CanvasStatus.Win:
                win.gameObject.SetActive(true);
                isGameActive = false;
                break;
            case CanvasStatus.GameOver: 
                gameOver.gameObject.SetActive(true);
                isGameActive = false; 
                break;

        }
    }

    
    public void OnStartButtonClick() 
    { 
        ChangeCanvasStatus(CanvasStatus.Play); 
        Debug.Log("start click");
    }
    
}


