using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PoolManager : Singleton<PoolManager>
{

    private Queue<GameObject> objectsPool;
    

    private Coroutine spawnCoroutine;
    

    

    private void HandleDroppingEggs(GameStatus status)
    {
        if (status == GameStatus.Playing) { StartDroping(); } else { StopDroping(); }
    }
    public void StartDroping()
    {
        

    }
    public void StopDroping()
    {
        
    }
    

    

    

    private IEnumerator DropEggsRoutine()
    {

        while (true)
        {
            
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
    
    
}

