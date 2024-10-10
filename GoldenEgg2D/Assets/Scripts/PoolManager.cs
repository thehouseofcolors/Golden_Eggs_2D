using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    private List<GameObject> eggList;
    private List<GameObject> chickenList;

    private Coroutine dropEggsCoroutine;
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<PoolManager>();
                    singletonObject.name = typeof(UI_Manager).ToString() + " (Singleton)";
                }
            }
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

        Debug.Log("pool manager awake");
    }
    
    private void Start()
    {
        Debug.Log("pool manager start");
    }

    private IEnumerator DropEggsRoutine()
    {

        eggList = SpawnGameObjects.Instance.GetEggPoolObjects();

        while (true)
        {
            foreach (GameObject egg in eggList)
            {
                if (!egg.activeInHierarchy)
                {
                    DropEgg(egg);
                    yield return new WaitForSeconds(2f);

                }
            }
            yield return new WaitForSeconds(2f);

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
        Transform chickenTransform = GetRandomChickenTransform();
        if (chickenTransform != null)
        {
            egg.transform.SetParent(chickenTransform);
            egg.transform.position = chickenTransform.position;

            egg.SetActive(false);
        }
    }
    public Transform GetRandomChickenTransform()
    {
        chickenList = SpawnGameObjects.Instance.GetChickenObjects();

        if (chickenList.Count > 0)
        {
            int randomIndex = Random.Range(0, chickenList.Count);
            return chickenList[randomIndex].transform;
        }
        return null;
    }


    public void StartDroping()
    {

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



}

