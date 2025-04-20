using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;  // Ses kayna��n� buraya ekleyin
    [SerializeField] private Image image;
    [SerializeField] private GameData gameData;
    
    public void Start()
    {
        image.sprite=gameData.GetLevelSprite(gameData.CurrentLevel);
    }
    public void OnEntryButtonClick() { LoadScene("MainMenu"); audioSource.Play(); }

    public void OnPlayButtonClick() => LoadScene("Game");


    public void OnSettingsButtonClick() => LoadScene("Settings");

    public void OnLevelsButtonClick() => LoadScene("Levels");


    public void OnHomeButtonClick() { LoadScene("MainMenu"); audioSource.Play(); }


    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    

}
