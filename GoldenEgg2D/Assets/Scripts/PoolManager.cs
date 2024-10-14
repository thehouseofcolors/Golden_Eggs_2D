using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{

    private List<GameObject> chickenList;
    private Queue<GameObject> eggPool;

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
   
   
    private void OnEnable()
    {
        CanvasManager.Instance.CanvasStatusChanged += HandleDroppingEggs;
    }
    private void Start()
    {
        eggPool = SpawnGameObjects.Instance.eggPool;
        chickenList = SpawnGameObjects.Instance.chickenList;
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
    public Transform GetRandomChichen()
    {
        return chickenList[Random.Range(0, chickenList.Count)].transform;
    }

    private void HandleDroppingEggs(CanvasStatus canvasStatus)
    {
        if (canvasStatus==CanvasStatus.Play) { StartDroping(); } else { StopDroping(); }
    }

    private void OnDestroy()
    {

        CanvasManager.Instance.CanvasStatusChanged -= HandleDroppingEggs;
    }

    private IEnumerator DropEggsRoutine()
    {

        while (true)
        {
            GameObject egg = GetRandomEgg();
            if (egg != null)
            {
                DropEgg(egg);
                yield return new WaitForSeconds(2f);
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
    

    public void StopDroping()
    {
        if (dropEggsCoroutine != null)
        {
            StopCoroutine(dropEggsCoroutine);
            dropEggsCoroutine = null;
        }
    }


    public GameObject GetRandomEgg() { return eggPool.Dequeue(); }
}

