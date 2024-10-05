using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ChickenPrefab;
    public GameObject RegularEggPrefab;
    
    public Transform PlayTilemap;     
    
    
    private List<GameObject> eggList=new List<GameObject>();    
    private List<GameObject> chickenList=new List<GameObject>();


    public float leftBoundary = -2f; 
    public float rightBoundary = 2f;  
    public float upperBoundary = 3f;

    public List<GameObject> GetEggList() {  return eggList; }
    public List<GameObject> GetChickenList() { return chickenList; }

    private EggPoolManager EggPoolManager;


    public void SpawnChicken()
    {
        if (ChickenPrefab == null)
        {
            Debug.LogError("ChickenPrefab is not assigned in the Inspector.");
           
        }

        if (PlayTilemap == null)
        {
            Debug.LogError("PlayTilemap is not assigned in the Inspector.");
            
        }

        Vector3 chickenPos = new Vector3(0, upperBoundary, 0);
        GameObject chicken = Instantiate(ChickenPrefab, chickenPos, Quaternion.Euler(0, 90, 0));
        chicken.SetActive(false);
        chicken.transform.SetParent(PlayTilemap);
        chickenList.Add(chicken);
        
    }
    public void SpawnEgg()
    {
        Transform chickenTransform = GetRandomChickenTransform();
        for (int i = 0; i < 3; i++)
        {
            Vector3 eggPos = new Vector3(chickenTransform.position.x, chickenTransform.position.y + 0.5f, chickenTransform.position.z);

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

        EggPoolManager = FindObjectOfType<EggPoolManager>();
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
