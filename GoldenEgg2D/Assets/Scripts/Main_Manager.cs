using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Manager : MonoBehaviour
{
    [SerializeField] private PrefabSettings prefabSettings;
    [SerializeField] private GameSettings gameSettings;
    
    private List<GameObject> chickenList = new List<GameObject>();
    
    public Transform playTilemap;

    private void Start()
    {
        SpawnPlayerAtBottomCenter();

        SpawnChicken();

    }

    void SpawnPlayerAtBottomCenter()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, Camera.main.nearClipPlane));
        spawnPosition.y += 1.0f;
        spawnPosition.z = 0;
        GameObject player = Instantiate(prefabSettings.GetPlayerPrefab(), spawnPosition, Quaternion.identity);
        player.SetActive(false);



    }



    void SpawnChicken()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane));
        spawnPosition.z = 0;
        GameObject chicken = Instantiate(prefabSettings.GetChickenPrefab(), spawnPosition, Quaternion.identity);
        chicken.SetActive(false);
        chickenList.Add(chicken);

    }
    void SpawnEggs()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
