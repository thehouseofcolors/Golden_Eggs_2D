using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    private bool movingRight = true;
    
    private int RandomSpeed() { return Random.Range(3,6); }

    void Update()
    {// Eðer Canvas durumu "Play" ise hareket et
        if (CanvasManager.Instance.currentCanvasStatus == CanvasStatus.Play)
        {
            Movement();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight;
        }
    }
    private void GoLeft()
    {
        transform.position += Vector3.left * RandomSpeed()* Time.deltaTime;
    }
    private void GoRight()
    {
        transform.position += Vector3.right * RandomSpeed() * Time.deltaTime;
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
