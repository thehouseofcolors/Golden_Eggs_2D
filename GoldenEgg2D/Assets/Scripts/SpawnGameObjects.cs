using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField] private PrefabSettings prefabSettings;
    [SerializeField] private Transform playTilemap;

    private List<GameObject> chickenList = new List<GameObject>();
    private List<GameObject> eggList = new List<GameObject>();

    private static SpawnGameObjects instance;
    public static SpawnGameObjects Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null) {instance = this;} else {Destroy(gameObject);}
        Debug.Log("spawmn objects awake");
    }

    private void Start()
    {
        Debug.Log("spawmn objects start");
    }
    public void SpawnPlayerAtBottomCenter()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, Camera.main.nearClipPlane));
        spawnPosition.y += 1.0f;
        spawnPosition.z = 0;
        GameObject player = Instantiate(prefabSettings.GetPlayerPrefab(), spawnPosition, Quaternion.identity);
        player.transform.SetParent(playTilemap);
        player.SetActive(true);

    }
    public void SpawnChicken()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.8f, Camera.main.nearClipPlane));
        spawnPosition.y -= 1.0f;
        spawnPosition.z = 0;

        GameObject chicken = Instantiate(prefabSettings.GetChickenPrefab(), spawnPosition, Quaternion.Euler(0,90,0));
        chicken.transform.SetParent(playTilemap);

        chickenList.Add(chicken);
        SpawnEggs(chicken, spawnPosition);
    }
    void SpawnEggs(GameObject chicken, Vector3 spawnPosition)
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 eggSpawnPosition = spawnPosition;
            eggSpawnPosition.x += i * 0.5f;
            GameObject egg = Instantiate(prefabSettings.GetRegularEggPrefab(), eggSpawnPosition, Quaternion.identity);
            egg.transform.SetParent(chicken.transform);
            egg.SetActive(false);
            eggList.Add(egg);

        }
    }

    public List<GameObject> GetEggPoolObjects() => eggList;
    public List<GameObject> GetChickenObjects() => chickenList;


}
