


public enum GameStatus
{
    Playing,
    Paused,
    Win,
    GameOver
}




public class GameManager : Singleton<GameManager>
{
    private int score;
    private int level;
    private GameStatus gameStatus;


    // GameManager başlangıcında gerekli şeyleri başlatıyoruz
    private void Start()
    {
        score = 0;
        gameStatus = GameStatus.Playing;

        // Skor ve oyun durumu başlangıcını eventler ile bildir
        EventBus.Publish(new ScoreChangedEvent(score));
        EventBus.Publish(new GameStatusChangedEvent(gameStatus));

    }

    // Skor değiştiğinde çağrılacak fonksiyon
    public void ChangeScore(int amount)
    {
        if (gameStatus != GameStatus.Playing) return;

        score += amount;
        EventBus.Publish(new ScoreChangedEvent(score));

        // Eğer skor hedefe ulaşırsa, oyunu kazandık
        
    }

    // Oyun durumu değiştiğinde tetiklenecek fonksiyon
    public void SetGameStatus(GameStatus newStatus)
    {
        if (gameStatus == newStatus) return;

        gameStatus = newStatus;
        EventBus.Publish(new GameStatusChangedEvent(gameStatus));

        // Oyun bitirse tekrar başlatma
        if (gameStatus == GameStatus.GameOver)
        {
            Invoke("RestartGame", 2f); // 2 saniye sonra oyunu yeniden başlat
        }
    }

    // Oyun bittiğinde yeniden başlat
    private void RestartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Aynı sahneyi yeniden yükle
    }
}

