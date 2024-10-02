using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Speed for smooth movement

    void Start()
    {

    }

    void Update()
    {
        Vector2 touchPosition = Vector2.zero;

        // Get touch or mouse position
        if (Input.touchCount > 0)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else if (Input.GetMouseButton(0))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // Only move horizontally
        Vector2 newPosition = new Vector2(touchPosition.x, transform.position.y);

        // Move the player to the new position
        transform.position = Vector2.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}