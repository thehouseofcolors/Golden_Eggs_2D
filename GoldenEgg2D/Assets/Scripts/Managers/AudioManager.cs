using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource playAudio;
    [SerializeField] private AudioSource winAudio;
    [SerializeField] private AudioSource gameoverAudio;

    private void OnEnable()
    {
        // Event'lere abone olma
        EventBus.Subscribe<ScoreChangedEvent>(OnScoreChanged); // Skor değiştiğinde ses çalma
        EventBus.Subscribe<GameStatusChangedEvent>(HandleGameStatus); // Oyun durumu değiştiğinde ses çalma
    }

    private void OnDestroy()
    {
        // Event'lerden abonelikleri kaldırma
        EventBus.Unsubscribe<ScoreChangedEvent>(OnScoreChanged);
        EventBus.Unsubscribe<GameStatusChangedEvent>(HandleGameStatus);
    }

    // Skor değiştiğinde ses çalma
    private void OnScoreChanged(ScoreChangedEvent e)
    {
        // Skor değiştiğinde oyun içi müzik çalmaya devam eder
        if (!playAudio.isPlaying)
        {
            playAudio.Play();
        }
    }

    // Oyun durumu değiştiğinde (game over veya kazandı) ses çalma
    private void HandleGameStatus(GameStatusChangedEvent e)
    {
        switch (e.NewStatus)
        {
            case GameStatus.Win:
                // Kazanma durumunda kazandığınız müziği çal
                if (!winAudio.isPlaying)
                {
                    winAudio.Play();
                }
                break;

            case GameStatus.GameOver:
                // Oyun bittiğinde game over müziğini çal
                if (!gameoverAudio.isPlaying)
                {
                    gameoverAudio.Play();
                }
                break;

            default:
                break;
        }
    }
}
