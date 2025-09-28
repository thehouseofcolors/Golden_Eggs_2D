using UnityEngine;
using System.Collections;


public class Spawner : Singleton<Spawner>
{
    [SerializeField] public PoolManager _config;

    // Cached references for performance
    private Transform _startLine;
    private Transform _endLine;
    private float _tileLength;
    private int _tilesPerRow;

    protected bool IsSpawning { get; private set; }
    protected Transform GroundParent => _config.groundParent;
    protected Transform ObjectParent => _config.objectParent;

    protected void Awake()
    {
        CacheConfigValues();

        if (_config.autoStartSpawning)
            StartSpawning();

        SpawnPlayer();
    }

    private void CacheConfigValues()
    {
        _startLine = _config.startLine;
        _endLine = _config.endLine;
        _tileLength = _config.tileLength;
        _tilesPerRow = _config.tilesPerRow;
    }

    private void SpawnPlayer()
    {
        if (_config.playerPrefab != null)
        {
            Instantiate(_config.playerPrefab, _config.playerPos, Quaternion.identity);
        }
    }

    public void StartSpawning()
    {
        if (!IsSpawning)
        {
            IsSpawning = true;
            StartCoroutine(SpawnRoutine());
        }
    }

    public void StopSpawning()
    {
        IsSpawning = false;
    }

    private IEnumerator SpawnRoutine()
    {
        var waitInterval = new WaitForSeconds(_config.spawnInterval);

        while (IsSpawning)
        {
            SpawnTileRow();
            SpawnObjectRow();
            yield return waitInterval;
        }
    }

    protected Vector3 GetSpawnPosition(int laneIndex)
    {
        float xPos = laneIndex * _tileLength - _tileLength * (_tilesPerRow - 1) * 0.5f;
        return new Vector3(xPos, 0, _startLine.position.z);
    }

    public void SpawnTileRow()
    {
        if (TileFactory.Instance == null) return;

        for (int i = 0; i < _config.tilesPerRow; i++)
        {
            var tile = TileFactory.Instance.GetRandomGroundTile();
            if (tile != null)
            {
                tile.transform.SetParent(GroundParent);
                tile.transform.position = GetSpawnPosition(i);
            }
        }
    }
    public void SpawnObjectRow()
    {
        if (TileFactory.Instance == null) return;

        for (int i = 0; i < _config.tilesPerRow; i++)
        {
            var tile = TileFactory.Instance.GetRandomObjectTile();
            if (tile != null)
            {
                tile.transform.SetParent(ObjectParent);
                tile.transform.position = GetSpawnPosition(i);
            }
        }
    }
}


