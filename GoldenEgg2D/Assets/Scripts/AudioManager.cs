using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource playAudio;
    [SerializeField] private AudioSource winAudio;
    [SerializeField] private AudioSource gameoverAudio;
    


    private void OnEnable()
    {
        GameController.Instance.GameStatusChanged += HandleAudio; 
    }
    private void OnDestroy()
    {
        GameController.Instance.GameStatusChanged -= HandleAudio;
    }
    private void HandleAudio(GameStatus status)
    {
        playAudio.Stop();
        winAudio.Stop();
        gameoverAudio.Stop();
        switch (status)
        {
            case GameStatus.Play: playAudio.Play(); break;
            case GameStatus.Win: winAudio.Play(); break;
            case GameStatus.GameOver: gameoverAudio.Play(); break;
            default: break;

        }
    }

    
}
