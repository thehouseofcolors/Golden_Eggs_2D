using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public int speed = 5;
    private bool movingRight = true;

    private Main_Manager main_manager;

    private void Start()
    {
        main_manager=FindObjectOfType<Main_Manager>();
    }
    void Update()
    {
        Movement();

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("play"))
        {
            movingRight = !movingRight;
        }
    }

    private void OnEnable()
    {
        main_manager.gameStatusChanged += UpdateChicken;

    }
    private void OnDestroy()
    {
        main_manager.gameStatusChanged -= UpdateChicken;

    }

    public void UpdateChicken(GameStatus status)
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
