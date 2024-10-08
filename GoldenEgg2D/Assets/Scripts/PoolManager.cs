using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{

    private Coroutine dropEggsCoroutine;

    private List<GameObject> eggList;
    private List<GameObject> chickenList;


    private static PoolManager _instance;
    private UI_Manager manager;

    private void Start()
    {
        manager=FindObjectOfType<UI_Manager>();
    }
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
                    singletonObject.name = typeof(Main_Manager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }


    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
    }
    private IEnumerator DropEggsRoutine()
    {

        eggList = SpawnGameObjects.Instance.GetEggPoolObjects();

        while (manager.currentStatus == GameStatus.Playing)
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


    private void OnEnable()
    {
        
        manager.gameStatusChanged += DropingState;
    }
    private void OnDestroy()
    {
        manager.gameStatusChanged -= DropingState;

    }

    public void DropingState(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Playing:
                StartDroping();
                break;
            default:
                StopDroping();
                break;
        }
    }


}

