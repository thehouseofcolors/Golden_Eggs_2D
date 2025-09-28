using UnityEngine;
using System.Collections.Generic;
using System;

public interface ITile<T> where T : System.Enum
{
    T Type { get; }
    GameObject prefab { get; }
    int count { get; }
}


public enum ObjectType { obs_1, egg, empty }
public enum GroundType { grn_1 }

public class TileFactory : Singleton<TileFactory>
{
    [SerializeField] private GroundController[] groundPrefabs;
    [SerializeField] private ObjectController[] objectPrefabs;

    private Dictionary<GroundType, Queue<GameObject>> groundPool;
    private Dictionary<ObjectType, Queue<GameObject>> objectPool;
    List<GroundTile> groundTypes = new List<GroundType>();
    List<ObjectType> objectTypes = new List<ObjectType>();
    void Awake()
    {
        groundTypes = CacheTileTypes<GroundController, GroundType>(groundPrefabs, c => c.groundTile.groundType);
        objectTypes = CacheTileTypes<ObjectController, ObjectType>(objectPrefabs, c => c.objectTile.objectType);

        InitializePools();
    }
    private List<TEnum> CacheTileTypes<TController, TEnum>( TController[] controllers, Func<TController, TEnum> selector)
    {
        var types = new List<TEnum>();
        foreach (var controller in controllers)
        {
            types.Add(selector(controller));
        }
        return types;
    }

    private void InitializePools()
    {
        try
        {
            groundPool = CreateTilePool(groundPrefabs, obj => obj.groundTile);
            objectPool = CreateTilePool(objectPrefabs, obj => obj.objectTile);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to initialize pools: {e.Message}");
            throw;
        }
    }

    private Dictionary<TEnum, Queue<GameObject>> CreateTilePool<TController, TEnum>
        (TController[] controllers, Func<TController, ITile<TEnum>> tileSelector) where TEnum : System.Enum
    {
        if (controllers == null || controllers.Length == 0)
        {
            throw new ArgumentException($"{typeof(TController).Name} array cannot be null or empty");
        }

        var pool = new Dictionary<TEnum, Queue<GameObject>>(controllers.Length);
        
        foreach (var controller in controllers)
        {
            var tile = tileSelector(controller);
            
            if (tile.prefab == null)
            {
                Debug.LogError($"Prefab for {typeof(TEnum).Name} {tile.Type} is null!");
                continue;
            }

            if (tile.count <= 0)
            {
                Debug.LogWarning($"Invalid count ({tile.count}) for {typeof(TEnum).Name} {tile.Type}");
                continue;
            }

            var queue = new Queue<GameObject>(tile.count);
            for (int i = 0; i < tile.count; i++)
            {
                var instance = Instantiate(tile.prefab, transform, false);
                instance.SetActive(false);
                queue.Enqueue(instance);
            }

            if (queue.Count > 0)
            {
                pool[tile.Type] = queue;
            }
        }
        Debug.Log("pool created");

        return pool;
    }

    public GameObject GetSceneTile()
    {
        GameObject ground = GetRandomGroundTile();
        GameObject obj = GetRandomObjectTile();
        obj.transform.SetParent(obj.transform);
        return ground;
    }
    private GameObject GetRandomGroundTile()
    {
        if (groundTypes == null || groundTypes.Count == 0)
        {
            Debug.LogError("Ground types list is empty!");
            return null;
        }

        var randomIndex = UnityEngine.Random.Range(0, groundTypes.Count);
        var randomType = groundTypes[randomIndex];

        return GetTile(groundPool, randomType);
    }


    private GameObject GetRandomObjectTile()
    {
        if (objectTypes == null || objectTypes.Count == 0)
        {
            Debug.LogError("Object types list is empty!");
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, objectTypes.Count);
        ObjectType randomType = objectTypes[randomIndex];
        if (randomType == ObjectType.empty) return null;
        return GetTile(objectPool, randomType);
    }
    


    private GameObject GetTile<TEnum>(Dictionary<TEnum, Queue<GameObject>> pool, TEnum type)
        where TEnum : System.Enum
    {
        if (pool != null && 
            pool.TryGetValue(type, out var queue) && 
            queue != null && 
            queue.Count > 0)
        {
            return queue.Dequeue();
        }

        return null;
    }



    public void ReleaseGroundTile(GroundType type, GameObject tile)
    {
        ReleaseTile(groundPool, type, tile);
    }

    public void ReleaseObjectTile(ObjectType type, GameObject tile)
    {
        ReleaseTile(objectPool, type, tile);
    }

    private void ReleaseTile<TEnum>(Dictionary<TEnum, Queue<GameObject>> pool, TEnum type, GameObject tile) 
        where TEnum : System.Enum
    {
        if (tile == null) return;

        tile.SetActive(false);
        tile.transform.SetParent(transform);

        if (pool != null && pool.TryGetValue(type, out var queue))
        {
            queue.Enqueue(tile);
        }
        else
        {
            Debug.LogWarning($"No pool exists for {typeof(TEnum).Name} {type}, destroying object");
            Destroy(tile);
        }
    }


    
}