using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    private bool movingRight = true;
    private Rigidbody2D rb;

    public float initialSpeed = 2f; // Baþlangýç hýzý
    public float acceleration = 0.5f; // Hýz artýþ miktarý
    public float maxSpeed = 10f; // Maksimum hýz

    private float currentSpeed; // Þu anki hýz

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
        currentSpeed = initialSpeed; // Baþlangýç hýzýný ayarla
    }

    void Update()
    {
        Movement();
        Accelerate(); // Hýzý artýr
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight; // Duvara çarptýðýnda yön deðiþtir
        }
    }

    private void Movement()
    {
        // Hareket yönünü hesapla
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        rb.velocity = direction * currentSpeed; // Hýzý uygula
    }

    private void Accelerate()
    {
        if (currentSpeed < maxSpeed) // Maksimum hýzdan düþükse artýr
        {
            currentSpeed += acceleration * Time.deltaTime; // Zamanla hýz artýr
        }
    }
}