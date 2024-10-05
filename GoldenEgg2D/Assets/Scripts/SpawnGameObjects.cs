using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField] private PrefabSettings prefabSettings;
    [SerializeField] private GameSettings gameSettings;

    private Main_Manager mainManager;


    private List<GameObject> chickenList = new List<GameObject>();
    private List<GameObject> eggList = new List<GameObject>();

    public Transform playTilemap;


    private void Start()
    {
        mainManager = FindObjectOfType<Main_Manager>();
        SpawnPlayerAtBottomCenter();
        SpawnChicken(1);
    }
    private void OnEnable()
    {
        mainManager.gameStatusChanged += HandleGameStatusChanged;
    }
    private void OnDestroy()
    {
        mainManager.gameStatusChanged -= HandleGameStatusChanged;
    }
    void SpawnPlayerAtBottomCenter()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, Camera.main.nearClipPlane));
        spawnPosition.y += 1.0f;
        spawnPosition.z = 0;
        GameObject player = Instantiate(prefabSettings.GetPlayerPrefab(), spawnPosition, Quaternion.identity);
        player.transform.SetParent(playTilemap);
        player.SetActive(false);

    }


    private void HandleGameStatusChanged(GameStatus status)
    {
        UpdateChicken(status, gameSettings.NextLevel());
        UpdatePlayer(status);
        
    }

    void SpawnChicken(int level)
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane));
        spawnPosition.x += 2;
        spawnPosition.z = 0;
        spawnPosition.y -= level;
        GameObject chicken = Instantiate(prefabSettings.GetChickenPrefab(), spawnPosition, Quaternion.identity);
        chicken.transform.SetParent(playTilemap);

        chicken.SetActive(false);
        chickenList.Add(chicken);
        for(int i = 0;i<3;i++)
        {
            Vector3 eggSpawnPosition = spawnPosition;
            eggSpawnPosition.x += i * 0.5f;
            GameObject egg = Instantiate(prefabSettings.GetRegularEggPrefab(), eggSpawnPosition, Quaternion.identity);
            egg.transform.SetParent(playTilemap);
            egg.SetActive(false);
            eggList.Add(egg);

        }
    }
    


    public void UpdateChicken(GameStatus status, int level)
    {
        switch (status)
        {
            case GameStatus.Entry:
                chickenList.Clear();
                eggList.Clear();

                SpawnChicken(1);
                break;
            case GameStatus.Playing:
                SpawnChicken(level);
               
                break;
            case GameStatus.Paused:

                break;
        }
    }


    public void UpdatePlayer(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Entry:
                SpawnPlayerAtBottomCenter();
                break;
            case GameStatus.Playing:
                break;
            case GameStatus.Paused:
                break;
        }
    }


}
