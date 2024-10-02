using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float speed = 0.01f;

    private bool movingRight;

    void Start()
    {

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
        
        // Y�n kontrol�ne g�re hareket et
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
        // Duvara �arpma durumu
        if (collision.gameObject.CompareTag("play"))
        {
            // Y�n� de�i�tir
            movingRight = !movingRight;
        }
    }

}
