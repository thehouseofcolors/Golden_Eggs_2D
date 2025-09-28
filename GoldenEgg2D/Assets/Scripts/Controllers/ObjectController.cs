using UnityEngine;


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

public class ObjectController : MonoBehaviour
{
    public ObjectTile objectTile;
    public float moveSpeed = 2f; // Zemin hareket hızı
    public float endZ = -10f;   // Zemin devre dışı bırakılma noktası

    void Update()
    {
        if (gameObject.transform.position.z <= Spawner.Instance._config.endLine.position.z) Recycle();
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

    }
    public void Recycle()
    {
        TileFactory.Instance.ReleaseObjectTile(objectTile.objectType, gameObject);
    }

}
