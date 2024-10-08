using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum SceneStatus { MainMenu, Game }
public class SceneLoad : MonoBehaviour
{
    public Image progressBar;
    public delegate void SceneChangeEvent();
    public event SceneChangeEvent ChangeTheScene;
    private SceneStatus currentStatus;

    private void Start()
    {
        Debug.Log("sceneload start");
    }

    public void ChangeSceneStatus(SceneStatus newStatus)
    {
        if (currentStatus != newStatus)
        {
            currentStatus = newStatus;
            HandleSceneChange(currentStatus);
        }
    }
    
    
    public void HandleSceneChange(SceneStatus status)
    { 
        switch (status)
        {
            case SceneStatus.MainMenu: StartCoroutine(LoadSceneAsync("MainMenu")); break;
            case SceneStatus.Game: StartCoroutine(LoadSceneAsync("Game")); break;

            default: Debug.LogWarning("geçersiz sahne!"); break;

        }
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOperation.isDone) { progressBar.fillAmount = asyncOperation.progress; yield return null; }
    }

    private void OnEnable()
    {

    }
    

    void OnDisable()
    {

    }
    

}
