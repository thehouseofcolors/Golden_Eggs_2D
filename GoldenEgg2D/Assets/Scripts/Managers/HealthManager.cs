using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int currentHealth;

    void Start()
    {
        currentHealth = 3; //sonra bunu merkezi bir yerden al
        
    }
    // Sağlık değiştiğinde çağrılacak method
    public void LoseLife()
    {
        currentHealth -= 1;

        // Event'i yayınla
        EventBus.Publish(new HealthChangedEvent(currentHealth));
    }
}
