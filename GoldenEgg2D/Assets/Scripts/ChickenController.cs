using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public int speed = 5;
    private bool movingRight = true;
    private UI_Manager manager;
    void Start()
    {
        manager = FindObjectOfType<UI_Manager>(); // Assuming UI_Manager is a singleton or in the scene.
    }

    void Update()
    {
        Movement();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("play"))
        {
            movingRight = !movingRight;
        }
    }
    private void GoLeft()
    {

        transform.position += Vector3.left * (speed) * Time.deltaTime;


    }
    private void GoRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    private void Movement()
    {

        if (movingRight)
        {
            GoRight();
        }
        else
        {
            GoLeft();
        }
    }
   

    private void OnEnable()
    {
        manager.gameStatusChanged += UpdateChicken;

    }
    private void OnDestroy()
    {
        manager.gameStatusChanged -= UpdateChicken;

    }

    public void UpdateChicken(GameStatus status)
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
