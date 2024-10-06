using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{

    private Coroutine dropEggsCoroutine;

    private List<GameObject> eggList;
    private List<GameObject> chickenList;

    private IEnumerator DropEggsRoutine()
    {

        eggList = SpawnGameObjects.Instance.GetEggPoolObjects();

        while (Main_Manager.Instance.currentStatus == GameStatus.Playing)
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
        Main_Manager.Instance.gameStatusChanged += DropingState;
    }
    private void OnDestroy()
    {
        Main_Manager.Instance.gameStatusChanged -= DropingState;

    }

    public void DropingState(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Entry:

                StopDroping();  
                break;
            case GameStatus.Playing:
                StartDroping();
                break;
            case GameStatus.Paused:
                StopDroping();
                break;
        }
    }


}

