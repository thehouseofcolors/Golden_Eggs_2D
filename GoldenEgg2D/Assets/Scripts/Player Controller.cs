using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Another instance of PlayerController already exists. Destroying this duplicate.");
            Destroy(gameObject); // Mevcut bir nesne varsa, yeni oluþturulan nesneyi yok et
        }
    }
    private void OnEnable()
    {
        Debug.Log("PlayerController etkinleþtirildi.");
        UI_Manager.Instance.CanvasStatusChanged += HandleStatusChange;
    }
    private void Start()
    {
        HandleStatusChange(UI_Manager.Instance.currentCanvasStatus);
    }
    public void HandleStatusChange(CanvasStatus status)
    {
        switch (status) { case CanvasStatus.Play: gameObject.SetActive(true); break;default: gameObject.SetActive(false); break; }
    }
    private void Update()
    {
        Vector2 touchPosition = Vector2.zero;

        if (Input.touchCount > 0)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else if (Input.GetMouseButton(0))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector2 newPosition = new Vector2(touchPosition.x, transform.position.y);

        transform.position = Vector2.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
    private void OnDisable()
    {
        Debug.Log("PlayerController devre dýþý býrakýldý.");
        UI_Manager.Instance.CanvasStatusChanged -= HandleStatusChange;
    }
}
