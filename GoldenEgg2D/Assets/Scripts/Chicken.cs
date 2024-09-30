using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float speed = 0.01f;


    public float leftBoundary = -1.8f;  // Left boundary of movement
    public float rightBoundary = 1.8f;  // Right boundary of movement
    //public float upperBoundary = 4f;

    private bool movingRight;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        if (collision.gameObject.CompareTag("chicken"))
        {
            // Y�n� de�i�tir
            movingRight = !movingRight;
        }
    }

}
