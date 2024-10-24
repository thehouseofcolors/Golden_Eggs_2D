using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnScene : MonoBehaviour
{
    private void OnEnable()
    {
        GameController.Instance.GameStatusChanged += HandleActiveObjects;
    }
    private void HandleActiveObjects(GameStatus Status)
    {
        gameObject.SetActive(Status ==GameStatus.Play);
    }
    private void OnDestroy()
    {
        GameController.Instance.GameStatusChanged -= HandleActiveObjects;
    }
}
