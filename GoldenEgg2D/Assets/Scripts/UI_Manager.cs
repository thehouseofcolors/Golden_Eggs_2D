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
        canvasGroup.alpha = 1;        // Þeffaflýðý kaldýrýr (görünür yapar)
        canvasGroup.interactable = true;  // UI elemanlarýnýn etkileþimini açar
        canvasGroup.blocksRaycasts = true; // Týklamalarý kabul eder
    }

    // Canvas'ý þeffaf yapar (gizli)
    public void HideCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;        // Þeffaf yapar (gizli)
        canvasGroup.interactable = false; // UI elemanlarýnýn etkileþimini kapatýr
        canvasGroup.blocksRaycasts = false; // Týklamalarý engeller
    }


}
public class EntryUIManager : UI_Manager
{
    [SerializeField] private TextMeshProUGUI countdownText; // Geri sayým metni
    private Coroutine countdownCoroutine;
    
    private void Start()
    {
        countdownText.gameObject.SetActive(false); // Geri sayým metnini gizle
    }

    public new void StartGame()
    {
        // Geri sayýmý baþlat
        countdownCoroutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {

        countdownText.gameObject.SetActive(true); // Geri sayým metnini görünür yap

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Geri sayýmý güncelle
            yield return new WaitForSeconds(1); // 1 saniye bekle
        }

        countdownText.text = "Go!"; // "Go!" yaz
        yield return new WaitForSeconds(1); // 1 saniye bekle

        countdownText.gameObject.SetActive(false); // Geri sayým metnini gizle
        ChangeGameStatus(GameStatus.Playing); // Oyunu baþlat
    }

}
public class PlayingUIManager : UI_Manager
{
    [SerializeField] private TextMeshProUGUI scoreText; // Puan metni
    [SerializeField] private TextMeshProUGUI timerText; // Zaman metni

    private float gameTime; // Oyun süresi
    private int score; // Oyun puaný

    // Oyun baþlatýldýðýnda zamanlayýcýyý baþlat
    public void StartTimer(float duration)
    {
        gameTime = duration; // Oyun süresini ayarla
        StartCoroutine(TimerCoroutine(duration));
    }
    private IEnumerator TimerCoroutine(float duration)
    {
        float timeRemaining = duration;

        while (timeRemaining >= 0)
        {
            // Kalan süreyi güncelleyin ve UI'ye yazdýrýn
            timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining);
            timeRemaining -= Time.deltaTime; // Geçen zamaný çýkar
            yield return null; // Bir sonraki frame'e geç
        }

        // Zaman sona erdiðinde yapýlacak iþlemler
        timerText.text = "Time's up!";
        // Oyun bitiþ durumu gibi iþlemleri çaðýrýn
        Win();
    }
    public void UpdateScore(int amount)
    {
        score += amount; // Puaný güncelle
        scoreText.text = $"Score: {score}"; // Puan metnini güncelle
    }

    public void GameOver()
    {
        ChangeGameStatus(GameStatus.GameOver); // Oyun bitiþ durumuna geç
    }

    public void Win()
    {
        ChangeGameStatus(GameStatus.Win); // Kazanma durumuna geç
    }
}

public class WinUIManager: UI_Manager
{

    private void OnNextButtonClick()
    {
        // Bir sonraki seviyenin adýný belirleyin (örneðin, "Level2")
        SceneManager.LoadScene("NextLevel"); // Bir sonraki seviyeyi yükle
    }

}
public class GameOverUIManager: UI_Manager
{
    private void OnTryAgainButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut seviyeyi tekrar yükle
    }

}