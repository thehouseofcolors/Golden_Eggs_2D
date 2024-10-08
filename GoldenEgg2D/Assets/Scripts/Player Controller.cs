using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private UI_Manager manager;
    public float speed = 5f;

    void Start()
    {
        manager = FindObjectOfType<UI_Manager>(); // Assuming UI_Manager is a singleton or in the scene.
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
    
    private void OnEnable()
    {
        manager.gameStatusChanged += UpdatePlayer;

    }
    private void OnDestroy()
    {
        manager.gameStatusChanged -= UpdatePlayer;

    }


    
    public void UpdatePlayer(GameStatus status)
    {

        gameObject.SetActive(false);
        switch (status)
        {

            case GameStatus.Playing:
                gameObject.SetActive(true);
                break;
            
        }
    }
}
