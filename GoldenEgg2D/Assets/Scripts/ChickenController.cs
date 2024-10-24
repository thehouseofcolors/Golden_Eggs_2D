using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    private bool movingRight = true;
    private Rigidbody2D rb;

    public float initialSpeed = 2f; // Ba�lang�� h�z�
    public float acceleration = 0.5f; // H�z art�� miktar�
    public float maxSpeed = 10f; // Maksimum h�z

    private float currentSpeed; // �u anki h�z

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
        currentSpeed = initialSpeed; // Ba�lang�� h�z�n� ayarla
    }

    void Update()
    {
        Movement();
        Accelerate(); // H�z� art�r
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight; // Duvara �arpt���nda y�n de�i�tir
        }
    }

    private void Movement()
    {
        // Hareket y�n�n� hesapla
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        rb.velocity = direction * currentSpeed; // H�z� uygula
    }

    private void Accelerate()
    {
        if (currentSpeed < maxSpeed) // Maksimum h�zdan d���kse art�r
        {
            currentSpeed += acceleration * Time.deltaTime; // Zamanla h�z art�r
        }
    }
}