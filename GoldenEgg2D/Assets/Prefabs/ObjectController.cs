using UnityEngine;


public class ObjectController : MonoBehaviour
{
    public ObjectTile objectTile;
    public float moveSpeed = 2f; // Zemin hareket hızı
    public float endZ = -10f;   // Zemin devre dışı bırakılma noktası

    void Update()
    {
        // Zemini Z ekseninde geri hareket ettir
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

        // // Zemin endZ'ye ulaştığında devre dışı bırak
        // if (transform.position.z <= endZ)
        // {
        //     gameObject.SetActive(false);
        // }
        
    }

}
