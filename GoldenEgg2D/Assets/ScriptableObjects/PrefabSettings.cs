using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PrefabSettings", menuName ="PrefabSettings") ]
public class PrefabSettings : ScriptableObject
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private GameObject regularEggPrefab;
    [SerializeField] private GameObject goldenEggPrefab;


    public Vector3[] chickenPositions; // Tavuk konumlar�n� saklamak i�in dizi

    // Belirli bir seviye i�in pozisyonu d�nd�r
    public Vector3 GetPosition(int level)
    {
        // Seviye 1'den ba�lar, dizinin 0'dan ba�lad���n� unutmay�n
        if (level - 1 >= 0 && level - 1 < chickenPositions.Length)
        {
            return chickenPositions[level - 1];
        }
        else
        {
            Debug.LogError("Level out of range: " + level);
            return Vector3.zero; // Hatal� durum i�in s�f�r vekt�r� d�nd�r
        }
    }

    public GameObject GetPlayerPrefab() => playerPrefab;
    public GameObject GetChickenPrefab() => chickenPrefab;
    public GameObject GetRegularEggPrefab() => regularEggPrefab;
    public GameObject GetGoldenEggPrefab() => goldenEggPrefab;

    

}
