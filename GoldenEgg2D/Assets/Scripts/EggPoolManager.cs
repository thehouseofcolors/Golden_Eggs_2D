using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EggPoolManager : MonoBehaviour
{
    public GameObject managerObject; // Assign the GameObject that has the Manager script


    public List<GameObject> eggList;
    public List<GameObject> chickenList;
    void Start()
    {
        Manager manager = managerObject.GetComponent<Manager>();
        eggList = manager.GetEggList();
        chickenList= manager.GetChickenList();
        DropEgg();
        StartCoroutine(DropEggsRoutine());
    }
    private IEnumerator DropEggsRoutine_()
    {
        while (true)
        {
            // Wait for 3 seconds before dropping the next egg
            yield return new WaitForSeconds(3f);
            GameObject egg = null;

            // Aktif olmayan bir yumurta bulana kadar d�ng�
            do
            {
                egg = eggList[Random.Range(0, eggList.Count)];
            }
            while (egg.activeInHierarchy); 

            egg.SetActive(true); 
            egg.transform.SetParent(null); 
        }
    }
    private IEnumerator DropEggsRoutine()//old
    {
        while (true)
        {
            foreach (GameObject egg in levelManager.GetEggList())
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
    public void ReAssine(GameObject egg)//old
    {

        GameObject randomChicken = chickenList[Random.Range(0, chickenList.Count)];
        Vector3 pos = randomChicken.transform.position;
        Vector3 eggPos = new Vector3(pos.x + Random.Range(-0.5f, 0.5f), pos.y, pos.z + 1); // Chicken'a yak�n bir pozisyon
        egg.transform.position = eggPos;
        egg.SetActive(false);
        egg.transform.SetParent(randomChicken.transform); // Yumurtay� chicken'a child yap
    }
    public void DropEgg()
    {
        GameObject egg = null;

        // Aktif olmayan bir yumurta bulana kadar d�ng�
        do
        {
            egg = eggList[Random.Range(0, eggList.Count)];
        }
        while (egg.activeInHierarchy); // Yumurta aktifse tekrar se�

        egg.SetActive(true); // Yumurta aktif yap�l�r
        egg.transform.parent = null; // Yumurtan�n ebeveyni kald�r�l�r (serbest b�rak�l�r)
    }
    public void AssignEggToRandomChicken(Egg egg)
    {
        // Reassign the egg to a random chicken when it hits the ground
        Transform chickenTransform = GetRandomChickenTransform();
        if (chickenTransform != null)
        {
            egg.transform.SetParent(chickenTransform);
            //egg.transform.localPosition = Vector3.zero; // Reset position to the chicken
            egg.gameObject.SetActive(false); // Deactivate or reset egg state
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

}

