using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayUIManager : Singleton<PlayUIManager>
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image[] healthImages;
    [SerializeField] private Sprite fullHealthSprite;
    [SerializeField] private Sprite emptyHealthSprite;


    private void OnEnable()
    {
        EventBus.Subscribe<ScoreChangedEvent>(OnScoreChanged);
        EventBus.Subscribe<LevelChangedEvent>(OnLevelChanged);
        EventBus.Subscribe<HealthChangedEvent>(OnHealthChanged);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<ScoreChangedEvent>(OnScoreChanged);
        EventBus.Unsubscribe<LevelChangedEvent>(OnLevelChanged);
        EventBus.Unsubscribe<HealthChangedEvent>(OnHealthChanged);
    }

    // Skor değiştiğinde UI'yi güncelle
    private void OnScoreChanged(ScoreChangedEvent e)
    {
        if(scoreText != null)
        {
            scoreText.text = $"Score: {e.NewScore}";
        }
    }

    // Seviye değiştiğinde UI'yi güncelle
    private void OnLevelChanged(LevelChangedEvent e)
    {
        if(levelText != null)
        {
            levelText.text = $"Level: {e.NewLevel}";
        }
    }
    private void OnHealthChanged(HealthChangedEvent e)
    {
        // Sağlık durumuna göre UI'yi güncelleme
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < e.CurrentHealth)
            {
                healthImages[i].sprite = fullHealthSprite;  // Dolu sprite
            }
            else
            {
                healthImages[i].sprite = emptyHealthSprite;  // Boş sprite
            }
        }
    
    }
}
