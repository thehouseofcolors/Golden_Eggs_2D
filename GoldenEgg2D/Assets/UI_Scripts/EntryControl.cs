using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryControl : MonoBehaviour
{
    public void OnEntryButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnPlayButtonClick()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Game");
    }
    public void OnContinueButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnTryAgainButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnSettingsButtonClick()
    {
        SceneManager.LoadScene("Settings");
    }
    public void OnLevelsButtonClick()
    {
        SceneManager.LoadScene("Levels");
    }




    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeLevel();
    }

    private void InitializeLevel()
    {

    }
}
