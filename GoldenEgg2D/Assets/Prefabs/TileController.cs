using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float startZ = 10f;   // Başlangıç Z pozisyonu
    public float endZ = -10f;    // Bitiş Z pozisyonu

    void Update()
    {
        // Z ekseninde aşağı doğru hareket
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Eğer endZ'ye gelirse, startZ'ye sıfırla
        if (transform.position.z <= endZ)
        {
            Vector3 newPos = transform.position;
            newPos.z = startZ;
            transform.position = newPos;
        }
    }
}
