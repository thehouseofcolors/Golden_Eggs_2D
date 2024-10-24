using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryControl : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;  // Ses kaynaðýný buraya ekleyin
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
