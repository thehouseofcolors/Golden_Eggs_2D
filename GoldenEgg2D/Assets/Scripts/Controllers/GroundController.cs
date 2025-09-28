using UnityEngine;

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

public class GroundController : MonoBehaviour
{
    public GroundTile groundTile;
    public Transform obstaclePoint;
    public float moveSpeed = 2f;

    void Update()
    {
        if (gameObject.transform.position.z <= Spawner.Instance._config.endLine.position.z) Recycle();
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
    }


    // Called when the tile needs to be recycled
    public void Recycle()
    {
        TileFactory.Instance.ReleaseGroundTile(groundTile.groundType, gameObject);
    }
}