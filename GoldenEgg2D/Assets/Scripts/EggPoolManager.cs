using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EggPoolManager : MonoBehaviour
{
    private Manager manager;

    private GameState gameState;

    private Coroutine dropEggsCoroutine; 

    private List<GameObject> eggList;
    private List<GameObject> chickenList;
    
    
    private IEnumerator DropEggsRoutine()
    {

        manager = FindObjectOfType<Manager>();
        eggList = manager.GetEggList();

        while (gameState == GameState.Playing)
        {
            foreach (GameObject egg in eggList)
            {
                if (!egg.activeInHierarchy) // Eðer yumurta aktif deðilse
                {
                    DropEgg(egg); // Yumurtayý düþür
                    yield return new WaitForSeconds(2f); // 2 saniye bekle
                }
            }

            // Tüm yumurtalar aktifse, 2 saniye bekle ve döngüyü baþtan baþlat
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
    

    public void ReAssignEgg(Egg egg)
    {

        Transform chickenTransform = GetRandomChickenTransform();
        if (chickenTransform != null)
        {
            egg.transform.SetParent(chickenTransform);
            egg.transform.position = chickenTransform.position;
            
            egg.gameObject.SetActive(false); 
        }
    }
    public Transform GetRandomChickenTransform()
    {
        chickenList = manager.GetChickenList();

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

