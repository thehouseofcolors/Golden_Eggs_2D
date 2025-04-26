using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private Transform parent;


    public Queue<GameObject> objectsPool = new Queue<GameObject>();

    

    
    
}
