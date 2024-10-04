using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ChickenPrefab;

    public Transform PlayTilemap;     
    public GameObject RegularEggPrefab;
    private Vector3 eggPos;
    private List<GameObject> eggList = new List<GameObject>();

    private Vector3 chickenPos;
    

    public float leftBoundary = -2f; 
    public float rightBoundary = 2f;  
    public float upperBoundary = 4f;

    public List<GameObject> chickenList;
    public List<GameObject> GetEggList() {  return eggList; }
    public List<GameObject> GetChickenList() { return chickenList; }

    private EggPoolManager EggPoolManager;

    // Start is called before the first frame update
    void Start()
    {
        SpawnChicken(1);
        chickenList = GetChickenList();
        SpawnEgg();
        EggPoolManager=FindObjectOfType<EggPoolManager>();
    }

    public GameObject SpawnChicken(int level)
    {
        chickenPos = new Vector3(0, upperBoundary-level, 0);
        GameObject chicken = Instantiate(ChickenPrefab, chickenPos, Quaternion.Euler(0, 90, 0));
        chicken.transform.SetParent(PlayTilemap);
        chickenList.Add(chicken);
        return chicken;
    }
    public void SpawnEgg()
    {
        Transform chickenTransform = GetRandomChickenTransform();
        for (int i = 0; i < 3; i++)
        {
            eggPos = new Vector3(chickenTransform.position.x, chickenTransform.position.y + 0.5f, chickenTransform.position.z);

            GameObject egg = Instantiate(RegularEggPrefab, eggPos, Quaternion.Euler(0, 0, 0));
            egg.transform.SetParent(chickenTransform); 
            egg.SetActive(false);
            eggList.Add(egg);
        }
    }

    public Transform GetRandomChickenTransform()
    {
        return chickenList[Random.Range(0,chickenList.Count)].transform;
    }

    public void StopGame()
    {
        EggPoolManager.StopDroping();

        foreach (GameObject chicken in chickenList)
        {
            chicken.SetActive(false);
        }

        foreach (GameObject egg in eggList)
        {
            egg.SetActive(false);
        }

    }

}
