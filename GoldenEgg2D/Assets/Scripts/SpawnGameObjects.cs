using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField] private Transform playTilemap;

    public List<GameObject> chickenList = new List<GameObject>();

    public Queue<GameObject> eggPool = new Queue<GameObject>();

    private static SpawnGameObjects instance;
    public static SpawnGameObjects Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null) {instance = this;} else {Destroy(gameObject);}
    }

    private void Start()
    {
        
        SpawnPlayer();
        SpawnChicken();
        SpawnEggs();
    }


    public void SpawnPlayer()
    {
        Vector3 spawnPosition = GameData.Instance.PlayerPos;

        GameObject player = Instantiate(GameData.Instance.PlayerPrefab, spawnPosition, Quaternion.identity);
        player.transform.SetParent(playTilemap);

    }
    public void SpawnChicken()
    {
        Vector3 spawnPosition = GameData.Instance.GetChickenPos(0);
        spawnPosition.z = 5;
        GameObject chicken = Instantiate(GameData.Instance.ChickenPrefab, spawnPosition, Quaternion.Euler(0, 90, 0));
        chicken.transform.SetParent(playTilemap);
        chickenList.Add(chicken);

        Vector3 _spawnPosition = GameData.Instance.GetChickenPos(1);
        _spawnPosition.z = 5;
        GameObject _chicken = Instantiate(GameData.Instance.ChickenPrefab, _spawnPosition, Quaternion.Euler(0, 90, 0));
        _chicken.transform.SetParent(playTilemap);
        
        // Mevcut h�z vekt�r�n� al
        Vector2 currentVelocity = _chicken.GetComponent<Rigidbody2D>().velocity;

        // H�z� art�r
        currentVelocity += new Vector2(1f, 0); // X ekseninde h�z art�rma

        // Yeni h�z� ata
        _chicken.GetComponent<Rigidbody2D>().velocity = currentVelocity;

        chickenList.Add(_chicken);

    }
    void SpawnEggs()
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 eggSpawnPosition = GetRandomChichen().transform.position;
            
            eggSpawnPosition.z = 0;
            GameObject egg = Instantiate(GameData.Instance.RegularEggPrefab, eggSpawnPosition, Quaternion.identity);
            egg.transform.SetParent(GetRandomChichen().transform    );
            
            egg.SetActive(false);
            eggPool.Enqueue(egg);

        }
    }
    public GameObject GetRandomChichen()
    {
        return chickenList[Random.Range(0, chickenList.Count)];
    }

    public GameObject GetRandomEgg() { return eggPool.Dequeue(); }
}
