using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject ChickenPrefab;
    
    public Transform chickenTilemap;     // Tavuklarýn ekleneceði Tilemap


    private Vector3 chickenPos;

    public float leftBoundary = -2f;  // Left boundary of movement
    public float rightBoundary = 2f;  // Right boundary of movement
    public float upperBoundary = 3f;


    // Start is called before the first frame update
    void Start()
    {
        chickenPos = new Vector2(0,3);

        GameObject gameObject = Instantiate(ChickenPrefab, chickenPos, Quaternion.Euler(0, 90, 0));
        gameObject.transform.SetParent(chickenTilemap);


    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
