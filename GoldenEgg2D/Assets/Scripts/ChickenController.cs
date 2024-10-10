using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public int speed = 5;
    private bool movingRight = true;
    private void Awake()
    {

    }
    private void OnEnable()
    {
        Debug.Log("ChickenController etkinleþtirildi.");
        UI_Manager.Instance.CanvasStatusChanged += HandleStatusChange;

    }
    private void Start()
    {
        HandleStatusChange(CanvasStatus.Countdown);
    }
    public void HandleStatusChange(CanvasStatus status)
    {
        Debug.Log($"HandleStatusChange çaðrýldý: {status}"); // Durum deðiþikliðini logla

        // Eðer "Play" durumu ise, objeyi aktif et
        if (status == CanvasStatus.Play)
        {
            Debug.Log("ChickenController aktif edildi."); // Log ekle
            gameObject.SetActive(true);
        }
        else if (status == CanvasStatus.Countdown) // Özel kontrol ekle
        {
            Debug.Log("ChickenController devre dýþý býrakýldý."); // Log ekle
            gameObject.SetActive(true);
        }
        else { gameObject.SetActive(false); }
    }

    private void OnDisable()
    {
        Debug.Log("ChickenController devre dýþý býrakýldý.");
        UI_Manager.Instance.CanvasStatusChanged -= HandleStatusChange;
    }

    void Update()
    {// Eðer Canvas durumu "Play" ise hareket et
        if (UI_Manager.Instance.currentCanvasStatus == CanvasStatus.Play)
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
