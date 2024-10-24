using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PoolManager : MonoBehaviour
{

    private List<GameObject> chickenList;
    private Queue<GameObject> eggPool;
    private float initialDropInterval = 2f; // Baþlangýçta yumurta düþme aralýðý
    private float dropIntervalDecreaseRate = 0.01f; // Azalma miktarý
    private float minimumDropInterval = 1f; // Minimum düþme aralýðý
    private float currentDropInterval; // Þu anki düþme aralýðý

    private Coroutine dropEggsCoroutine;
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        eggPool = SpawnGameObjects.Instance.eggPool;
        chickenList = SpawnGameObjects.Instance.chickenList;
        currentDropInterval = initialDropInterval;
    }


    private void OnEnable()
    {
        GameController.Instance.GameStatusChanged += HandleDroppingEggs;
    }
    private void OnDestroy()
    {
        GameController.Instance.GameStatusChanged -= HandleDroppingEggs;
    }
    

    private void HandleDroppingEggs(GameStatus status)
    {
        if (status == GameStatus.Play) { StartDroping(); } else { StopDroping(); }
    }
    public void StartDroping()
    {
        // Initialize eggPool when starting to drop eggs
        if (eggPool == null)
        {
            eggPool = SpawnGameObjects.Instance.eggPool; // Initialize here
        }

        if (dropEggsCoroutine == null)
        {
            dropEggsCoroutine = StartCoroutine(DropEggsRoutine());
        }

    }
    public void StopDroping()
    {
        if (dropEggsCoroutine != null)
        {
            StopCoroutine(dropEggsCoroutine);
            dropEggsCoroutine = null;
        }
    }
    

    

    

    private IEnumerator DropEggsRoutine()
    {

        while (true)
        {
            GameObject egg = GetRandomEgg();
            if (egg != null)
            {
                DropEgg(egg);
                yield return new WaitForSeconds(currentDropInterval);

                // Zaman aralýðýný azalt
                currentDropInterval = Mathf.Max(currentDropInterval - dropIntervalDecreaseRate, minimumDropInterval);
            }
            else
            {
                yield return null; // Wait for the next frame if no eggs are available
            }
        }

        
    }
    public void DropEgg(GameObject egg)
    {
        if (!egg.activeInHierarchy)
        {
            egg.SetActive(true);
            egg.transform.SetParent(null);
        }

    }
    public Transform GetRandomChichen()
    {
        return chickenList[Random.Range(0, chickenList.Count)].transform;
    }

    public void ReAssignEgg(GameObject egg)
    {
        Transform chickenTransform = GetRandomChichen();
        if (chickenTransform != null)
        {
            egg.transform.SetParent(chickenTransform);
            egg.transform.position = chickenTransform.position;
            egg.SetActive(false);
            eggPool.Enqueue(egg);
        }
    }
    

    


    public GameObject GetRandomEgg() { return eggPool.Dequeue(); }
}

