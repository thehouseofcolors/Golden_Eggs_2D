using UnityEngine;
using System.Collections.Generic;
using System;

public interface ITile<T> where T : System.Enum
{
    T Type { get; }
    GameObject prefab { get; }
    int count { get; }
}

[System.Serializable]
public class GroundTile : ITile<GroundType>
{
    public GroundType groundType;
    public GameObject prefab;
    public int count;
    
    public GroundType Type => groundType;
    GameObject ITile<GroundType>.prefab => prefab;
    int ITile<GroundType>.count => count;
}

[System.Serializable]
public struct ObjectTile : ITile<ObjectType>
{
    public ObjectType objectType;
    public GameObject prefab;
    public int count;
    
    public ObjectType Type => objectType;
    GameObject ITile<ObjectType>.prefab => prefab;
    int ITile<ObjectType>.count => count;
}

public enum ObjectType { obs_1, egg, empty }
public enum GroundType { grn_1 }

public class TileFactory : Singleton<TileFactory>
{
    [SerializeField] private GroundController[] groundPrefabs;
    [SerializeField] private ObjectController[] objectPrefabs;

    private Dictionary<GroundType, Queue<GameObject>> groundPool;
    private Dictionary<ObjectType, Queue<GameObject>> objectPool;

    void Awake()
    {
        InitializePools();
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

    private Dictionary<TEnum, Queue<GameObject>> CreateTilePool<TController, TEnum>(
        TController[] controllers, 
        Func<TController, ITile<TEnum>> tileSelector) 
        where TEnum : System.Enum
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

        return pool;
    }

    public GameObject GetGroundTile(GroundType groundType)
    {
        return GetTile(groundPool, groundType);
    }

    public GameObject GetObjectTile(ObjectType objectType)
    {
        return GetTile(objectPool, objectType);
    }

    private GameObject GetTile<TEnum>(Dictionary<TEnum, Queue<GameObject>> pool, TEnum type) 
        where TEnum : System.Enum
    {
        if (pool == null)
        {
            Debug.LogError($"{typeof(TEnum).Name} pool has not been initialized!");
            return null;
        }

        if (!pool.TryGetValue(type, out var queue))
        {
            Debug.LogError($"No pool exists for {typeof(TEnum).Name}: {type}");
            return null;
        }

        if (queue.Count == 0)
        {
            Debug.LogWarning($"Pool exhausted for {typeof(TEnum).Name}: {type}");
            return null;
        }

        var instance = queue.Dequeue();
        instance.SetActive(true);
        return instance;
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