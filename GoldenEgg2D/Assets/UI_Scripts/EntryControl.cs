using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryControl : MonoBehaviour
{
   

    public void OnEntryButtonClick() => LoadScene("MainMenu");

    public void OnPlayButtonClick() => LoadScene("Game");
    public void OnContinueButtonClick() => LoadScene("MainMenu");

    public void OnTryAgainButtonClick() => LoadScene(SceneManager.GetActiveScene().name);
  
    public void OnSettingsButtonClick() => LoadScene("Settings");

    public void OnLevelsButtonClick() => LoadScene("Levels");


    public void OnHomeButtonClick() => LoadScene("MainMenu");
    

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    

}
