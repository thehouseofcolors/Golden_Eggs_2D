using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGameObjects : MonoBehaviour
{
    public static SpawnGameObjects Instance { get; private set; }


    [SerializeField] private PrefabSettings prefabSettings;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Transform playTilemap;
    private List<GameObject> chickenList = new List<GameObject>();
    private List<GameObject> eggList = new List<GameObject>();

    private GameObject player;

    private UI_Manager manager;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        manager=FindObjectOfType<UI_Manager>();
        SpawnPlayerAtBottomCenter();
    }
    void SpawnPlayerAtBottomCenter()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, Camera.main.nearClipPlane));
        spawnPosition.y += 1.0f;
        spawnPosition.z = 0;
        player = Instantiate(prefabSettings.GetPlayerPrefab(), spawnPosition, Quaternion.identity);
        player.transform.SetParent(playTilemap);
        player.SetActive(false);

    }
    void SpawnChicken(int level)
    {
        //Vector3 spawnPosition=prefabSettings.GetPosition(1);
        

        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.8f, Camera.main.nearClipPlane));
        spawnPosition.y += 1.0f;
        spawnPosition.z = 0;

        GameObject chicken = Instantiate(prefabSettings.GetChickenPrefab(), spawnPosition, Quaternion.Euler(0,90,0));
        chicken.transform.SetParent(playTilemap);

        chicken.SetActive(true);
        chickenList.Add(chicken);
        SpawnEggs(chicken, spawnPosition);
    }

    void SpawnEggs(GameObject chicken, Vector3 spawnPosition)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 eggSpawnPosition = spawnPosition;
            eggSpawnPosition.x += i * 0.5f;
            GameObject egg = Instantiate(prefabSettings.GetRegularEggPrefab(), eggSpawnPosition, Quaternion.identity);
            egg.transform.SetParent(chicken.transform);
            egg.SetActive(false);
            eggList.Add(egg);

        }
    }

    private void OnEnable()
    {
        manager.gameStatusChanged += HandleGameStatusChanged;
    }
    private void OnDestroy()
    {
        manager.gameStatusChanged -= HandleGameStatusChanged;
    }
    
   
    private void HandleGameStatusChanged(GameStatus status)
    {
        UpdateChicken(status, gameSettings.NextLevel());
        UpdatePlayer(status);
        
    }

    

    public void UpdateChicken(GameStatus status, int level)
    {
        switch (status)
        {
            case GameStatus.Entry:
                chickenList.Clear();
                eggList.Clear();

                break;
            case GameStatus.Playing:
                SpawnChicken(level);
               
                break;
            
        }
    }


    public void UpdatePlayer(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Entry:
                player.SetActive(false);
                break;
            case GameStatus.Playing:
                player.SetActive(true);
                break;
        }
    }
    public List<GameObject> GetEggPoolObjects() => eggList;
    public List<GameObject> GetChickenObjects() => chickenList;


}
