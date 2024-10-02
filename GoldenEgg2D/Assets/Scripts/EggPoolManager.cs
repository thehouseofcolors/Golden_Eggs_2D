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
        StartCoroutine(DropEggsRoutine());
    }
    private IEnumerator DropEggsRoutine()
    {
        while (true)
        {
            // Wait for 3 seconds before dropping the next egg
            yield return new WaitForSeconds(3f);
            DropEgg();
        }
    }
    public void DropEgg()
    {
        GameObject egg = eggList[Random.Range(0, eggList.Count)];
        egg.SetActive(true);
        egg.transform.parent = null;
    }
    public void AssignEggToRandomChicken(Egg egg)
    {
        // Reassign the egg to a random chicken when it hits the ground
        Transform chickenTransform = GetRandomChickenTransform();
        if (chickenTransform != null)
        {
            egg.transform.SetParent(chickenTransform);
            egg.transform.localPosition = Vector3.zero; // Reset position to the chicken
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

