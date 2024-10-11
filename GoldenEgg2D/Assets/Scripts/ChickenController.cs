using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public int speed = 5;
    private bool movingRight = true;
    

    void Update()
    {// Eðer Canvas durumu "Play" ise hareket et
        if (CanvasManager.Instance.currentCanvasStatus == CanvasStatus.Play)
        {
            Movement();
        }
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
   
}
