using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ChickenPrefab;
    public GameObject RegularEggPrefab;
    //public GameObject GoldenEggPrefab;


    public Transform PlayTilemap;     // Tavuklarýn ekleneceði Tilemap
    

    private Vector3 chickenPos;
    private Vector3 eggPos;

    public float leftBoundary = -2f;  // Left boundary of movement
    public float rightBoundary = 2f;  // Right boundary of movement
    public float upperBoundary = 4f;

    private List<GameObject> chickenList = new List<GameObject>();
    private List<GameObject> eggList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        GameObject chicken=SpawmChicken(1);

        SpawmEgg(chicken);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject SpawmChicken(int level)
    {
        chickenPos = new Vector3(0, upperBoundary-level, 0);
        GameObject gameObject = Instantiate(ChickenPrefab, chickenPos, Quaternion.Euler(0, 90, 0));
        gameObject.transform.SetParent(PlayTilemap);
        chickenList.Add(gameObject);
        return gameObject;
    }

    public void SpawmEgg(GameObject chicken)
    {
        Vector3 eggPos = new Vector3(chicken.transform.position.x, chicken.transform.position.y , 0);

        GameObject egg = Instantiate(RegularEggPrefab, eggPos, Quaternion.Euler(0, 0, 0));
        egg.transform.SetParent(chicken.transform);

        eggList.Add(egg);

    }

}
