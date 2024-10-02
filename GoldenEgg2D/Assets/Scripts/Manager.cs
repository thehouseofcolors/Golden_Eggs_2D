using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ChickenPrefab;

    public Transform PlayTilemap;     // Tavuklarýn ekleneceði Tilemap
    public GameObject RegularEggPrefab;
    private Vector3 eggPos;
    private List<GameObject> eggList = new List<GameObject>();

    private Vector3 chickenPos;
    

    public float leftBoundary = -2f;  // Left boundary of movement
    public float rightBoundary = 2f;  // Right boundary of movement
    public float upperBoundary = 4f;

    public List<GameObject> chickenList = new List<GameObject>();
    public List<GameObject> GetEggList() {  return eggList; }
    public List<GameObject> GetChickenList() { return chickenList; }


    // Start is called before the first frame update
    void Start()
    {
        SpawnChicken(1);
        SpawnEgg();

    }

    // Update is called once per frame
    void Update()
    {

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
            egg.transform.SetParent(chickenTransform); // Ensure egg is parented to chicken
            //egg.SetActive(false); // You might want to activate the egg later
            eggList.Add(egg);
        }
    }

    public Transform GetRandomChickenTransform()
    {
        return chickenList[0].transform;
    }

}
