using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnScene : MonoBehaviour
{

    private void OnEnable()
    {
        CanvasManager.Instance.CanvasStatusChanged += HandleActiveObjects;
    }
    private void HandleActiveObjects(CanvasStatus canvasStatus)
    {
        gameObject.SetActive(canvasStatus == CanvasStatus.Play);
    }
    private void OnDestroy()
    {
        CanvasManager.Instance.CanvasStatusChanged -= HandleActiveObjects;
    }
}
