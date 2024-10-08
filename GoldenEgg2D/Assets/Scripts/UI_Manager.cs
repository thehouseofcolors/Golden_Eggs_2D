using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameStatus { Entry, Playing, Win, GameOver }
public class UI_Manager : MonoBehaviour
{
    private CanvasGroup Entry;
    private CanvasGroup Play;
    private CanvasGroup Win;
    private CanvasGroup GameOver;

    [SerializeField] private GameObject entry;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;


    public event Action<GameStatus> gameStatusChanged;

    public GameStatus currentStatus = GameStatus.Entry;


    public void ChangeGameStatus(GameStatus newStatus)
    {
        if (currentStatus != newStatus)
        {
            currentStatus = newStatus;
            gameStatusChanged?.Invoke(currentStatus);

        }
    }

    public void StartGame()
    {
        ChangeGameStatus(GameStatus.Playing);
    }


    private void Start()
    {
        Entry= entry.GetComponent<CanvasGroup>();
        Play=play.GetComponent <CanvasGroup>();
        Win=win.GetComponent <CanvasGroup>();
        GameOver=gameOver.GetComponent <CanvasGroup>();
    }
    

    private void OnEnable()
    {
        gameStatusChanged += UpdateUI;
    }
    private void OnDestroy()
    {
        gameStatusChanged -= UpdateUI;
    }

    public void UpdateUI(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Entry:
                ShowCanvas(Entry);
                HideCanvas(Play);
                HideCanvas(Win);
                HideCanvas(GameOver);
                break;
            case GameStatus.Playing:
                ShowCanvas(Play);
                HideCanvas(Entry);
                HideCanvas(Win);
                HideCanvas(GameOver);
                break;
            case GameStatus.Win:
                ShowCanvas(Win);
                HideCanvas(Entry);
                HideCanvas(Play);
                HideCanvas(GameOver);
                break;
            case GameStatus.GameOver:
                ShowCanvas(GameOver);
                HideCanvas(Entry);
                HideCanvas(Play);
                HideCanvas(Win);
                break;
        }
    }
   

    public void ShowCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;        // �effafl��� kald�r�r (g�r�n�r yapar)
        canvasGroup.interactable = true;  // UI elemanlar�n�n etkile�imini a�ar
        canvasGroup.blocksRaycasts = true; // T�klamalar� kabul eder
    }

    // Canvas'� �effaf yapar (gizli)
    public void HideCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;        // �effaf yapar (gizli)
        canvasGroup.interactable = false; // UI elemanlar�n�n etkile�imini kapat�r
        canvasGroup.blocksRaycasts = false; // T�klamalar� engeller
    }


}
public class EntryUIManager : UI_Manager
{
    [SerializeField] private TextMeshProUGUI countdownText; // Geri say�m metni
    private Coroutine countdownCoroutine;
    
    private void Start()
    {
        countdownText.gameObject.SetActive(false); // Geri say�m metnini gizle
    }

    public new void StartGame()
    {
        // Geri say�m� ba�lat
        countdownCoroutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {

        countdownText.gameObject.SetActive(true); // Geri say�m metnini g�r�n�r yap

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Geri say�m� g�ncelle
            yield return new WaitForSeconds(1); // 1 saniye bekle
        }

        countdownText.text = "Go!"; // "Go!" yaz
        yield return new WaitForSeconds(1); // 1 saniye bekle

        countdownText.gameObject.SetActive(false); // Geri say�m metnini gizle
        ChangeGameStatus(GameStatus.Playing); // Oyunu ba�lat
    }

}
public class PlayingUIManager : UI_Manager
{
    [SerializeField] private TextMeshProUGUI scoreText; // Puan metni
    [SerializeField] private TextMeshProUGUI timerText; // Zaman metni

    private float gameTime; // Oyun s�resi
    private int score; // Oyun puan�

    // Oyun ba�lat�ld���nda zamanlay�c�y� ba�lat
    public void StartTimer(float duration)
    {
        gameTime = duration; // Oyun s�resini ayarla
        StartCoroutine(TimerCoroutine(duration));
    }
    private IEnumerator TimerCoroutine(float duration)
    {
        float timeRemaining = duration;

        while (timeRemaining >= 0)
        {
            // Kalan s�reyi g�ncelleyin ve UI'ye yazd�r�n
            timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining);
            timeRemaining -= Time.deltaTime; // Ge�en zaman� ��kar
            yield return null; // Bir sonraki frame'e ge�
        }

        // Zaman sona erdi�inde yap�lacak i�lemler
        timerText.text = "Time's up!";
        // Oyun biti� durumu gibi i�lemleri �a��r�n
        Win();
    }
    public void UpdateScore(int amount)
    {
        score += amount; // Puan� g�ncelle
        scoreText.text = $"Score: {score}"; // Puan metnini g�ncelle
    }

    public void GameOver()
    {
        ChangeGameStatus(GameStatus.GameOver); // Oyun biti� durumuna ge�
    }

    public void Win()
    {
        ChangeGameStatus(GameStatus.Win); // Kazanma durumuna ge�
    }
}

public class WinUIManager: UI_Manager
{

    private void OnNextButtonClick()
    {
        // Bir sonraki seviyenin ad�n� belirleyin (�rne�in, "Level2")
        SceneManager.LoadScene("NextLevel"); // Bir sonraki seviyeyi y�kle
    }

}
public class GameOverUIManager: UI_Manager
{
    private void OnTryAgainButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut seviyeyi tekrar y�kle
    }

}