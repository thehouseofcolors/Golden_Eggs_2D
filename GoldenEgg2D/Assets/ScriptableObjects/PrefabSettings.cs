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
    public GameObject GetPlayerPrefab() => playerPrefab;
    public GameObject GetChickenPrefab() => chickenPrefab;
    public GameObject GetRegularEggPrefab() => regularEggPrefab;
    public GameObject GetGoldenEggPrefab() => goldenEggPrefab;


}
