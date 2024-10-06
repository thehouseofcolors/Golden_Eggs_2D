using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;

    private void Start()
    {
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
        Main_Manager.Instance.gameStatusChanged += UpdatePlayer;

    }
    private void OnDestroy()
    {
        Main_Manager.Instance.gameStatusChanged -= UpdatePlayer;

    }


    
    public void UpdatePlayer(GameStatus status)
    {
        switch (status)
        {
            case GameStatus.Entry:
                gameObject.SetActive(false);
                break;
            case GameStatus.Playing:
                gameObject.SetActive(true);
                break;
            case GameStatus.Paused:
                gameObject.SetActive(false);
                break;
        }
    }
}
