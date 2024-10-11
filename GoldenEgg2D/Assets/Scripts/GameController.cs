using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;


    private float gameTime;
    private int currentScore;
    private int currentLevel;

    private static GameController instance;
    public static GameController Instance {  get { return instance; } }
    private void Awake()
    {
        Debug.Log("gamecontrol awakw");
        instance = this;
    }
    
    
    private void Start()
    {
       
    }

    private void OnEnable()
    {
        Debug.Log("Gamecontrol onenable");
        CanvasManager.Instance.CanvasStatusChanged += HandleGameActiveState;
    }
    private void OnDestroy()
    {
        CanvasManager.Instance.CanvasStatusChanged -= HandleGameActiveState;
    }
    public void HandleGameActiveState(CanvasStatus status)
    {
        if (status == CanvasStatus.Play)
        {
            ResetUI();
        }
        
    }

    public void ResetUI()
    {
        gameTime = gameSettings.ResetTime();
        currentScore = gameSettings.ResetScore();
        currentLevel = gameSettings.currentLevel;
    }
}
