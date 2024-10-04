using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EggPoolManager : MonoBehaviour
{
    public GameObject managerObject; // Assign the GameObject that has the Manager script
    private Manager manager;

    private Coroutine dropEggsCoroutine; // Store reference to the coroutine

    public List<GameObject> eggList;
    public List<GameObject> chickenList;
    void Start()
    {
        manager = managerObject.GetComponent<Manager>();
        eggList = manager.GetEggList();
        chickenList= manager.GetChickenList();

        dropEggsCoroutine = StartCoroutine(DropEggsRoutine());
    }
    
    private IEnumerator DropEggsRoutine()
    {
        while (true)
        {
            foreach (GameObject egg in eggList)
            {
                if (!egg.activeInHierarchy) // E�er yumurta aktif de�ilse
                {
                    DropEgg(egg); // Yumurtay� d���r
                    yield return new WaitForSeconds(2f); // 2 saniye bekle
                }
            }

            // T�m yumurtalar aktifse, 2 saniye bekle ve d�ng�y� ba�tan ba�lat
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
        if (chickenList.Count > 0)
        {
            int randomIndex = Random.Range(0, chickenList.Count);
            return chickenList[randomIndex].transform;
        }
        return null;
    }
    public void StopDroping()
    {
        if (dropEggsCoroutine != null) // Ensure the coroutine reference is not null
        {
            StopCoroutine(dropEggsCoroutine); // Stop the coroutine using the reference
            dropEggsCoroutine = null; // Reset the reference
        }
    }
}

