using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField] private Transform playTilemap;

    public List<GameObject> chickenList = new List<GameObject>();

    public Queue<GameObject> eggPool = new Queue<GameObject>();

    private List<Vector3> chickenPosList= new List<Vector3>();
    

    private static SpawnGameObjects instance;
    public static SpawnGameObjects Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null) {instance = this;} else {Destroy(gameObject);}
    }

    private void Start()
    {
        chickenPosList.Add(GameData.Instance.ChickenPos);
        SpawnPlayer();
        for(int i = 0; i < GameData.Instance.CurrentLevel; i++) { SpawnChicken(); }
        
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
        Vector3 _spawnPosition = chickenPosList[chickenPosList.Count-1];
        _spawnPosition.y -= 1;
        GameObject _chicken = Instantiate(GameData.Instance.ChickenPrefab, _spawnPosition, Quaternion.Euler(0, 90, 0));
        _chicken.transform.SetParent(playTilemap);
        chickenPosList.Add(_spawnPosition);
        //_chicken.GetComponent<Rigidbody2D>().velocity *= 1;
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
