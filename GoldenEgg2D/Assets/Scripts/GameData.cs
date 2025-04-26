
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 

[CreateAssetMenu(fileName ="GameData", menuName ="Game Data", order = 1)]
public class GameData: ScriptableObject
{
    [SerializeField] private Sprite[] levels;


    [Header("Prefabs")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private GameObject regularEggPrefab;
    [SerializeField] private GameObject goldenEggPrefab;


    

    
    // Read-only properties

    public GameObject PlayerPrefab => playerPrefab;
    public GameObject ChickenPrefab => chickenPrefab;
    public GameObject RegularEggPrefab => regularEggPrefab;
    public GameObject GoldenEggPrefab => goldenEggPrefab;
    
    public Sprite GetLevelSprite(int level)
    {
        if (level <= 0 || level > levels.Length)
        {
            Debug.LogWarning("Invalid level index");
            return null; // veya bir varsayılan sprite dönebilirsiniz
        }
        return levels[level - 1];
    }



    
    

    

    
}
