using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameData.Instance.CurrentGameStatus = GameStatus.Pause;
    }
    private void Start()
    {
        Debug.Log("GameController Start");

        // Initialize level data
        GameData.Instance.InitializeLevel();

        // Use a coroutine to ensure that all event subscriptions have occurred before changing game status
        StartCoroutine(DelayedGameStatusChange());
    }

    private System.Collections.IEnumerator DelayedGameStatusChange()
    {
        // Wait one frame to ensure other scripts have had a chance to subscribe to the event
        yield return null;

        // Now that other scripts should have subscribed, we can set the game status to Play
        SetGameStatus(GameStatus.Play);
    }
    


    public event Action<GameStatus> GameStatusChanged;

    public void SetGameStatus(GameStatus newStatus)
    {
        Debug.Log($"Attempting to set GameStatus to: {newStatus}");
        if (GameData.Instance.CurrentGameStatus != newStatus)
        {
            GameData.Instance.CurrentGameStatus = newStatus;
            Debug.Log("GameStatus changed, invoking GameStatusChanged event.");
            GameStatusChanged?.Invoke(newStatus);
        }
        else
        {
            Debug.Log("GameStatus remains the same, no event triggered.");
        }
    }



}
