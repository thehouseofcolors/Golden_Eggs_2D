using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    private bool movingRight = true;
    private Rigidbody2D rb;

    private float speed = 5f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight; 
        }
    }

    private void Movement()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        rb.velocity = direction * speed; 
    }

}