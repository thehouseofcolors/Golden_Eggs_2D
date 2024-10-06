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


    public Vector3[] chickenPositions; // Tavuk konumlarýný saklamak için dizi

    // Belirli bir seviye için pozisyonu döndür
    public Vector3 GetPosition(int level)
    {
        // Seviye 1'den baþlar, dizinin 0'dan baþladýðýný unutmayýn
        if (level - 1 >= 0 && level - 1 < chickenPositions.Length)
        {
            return chickenPositions[level - 1];
        }
        else
        {
            Debug.LogError("Level out of range: " + level);
            return Vector3.zero; // Hatalý durum için sýfýr vektörü döndür
        }
    }

    public GameObject GetPlayerPrefab() => playerPrefab;
    public GameObject GetChickenPrefab() => chickenPrefab;
    public GameObject GetRegularEggPrefab() => regularEggPrefab;
    public GameObject GetGoldenEggPrefab() => goldenEggPrefab;

    

}
