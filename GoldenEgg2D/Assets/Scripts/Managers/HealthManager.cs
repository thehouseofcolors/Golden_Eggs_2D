using System;
using UnityEngine;
public struct HealthChangedEvent
{
    public int CurrentHealth;

    public HealthChangedEvent(int currentHealth)
    {
        CurrentHealth = currentHealth;
    }
}

public class HealthManager : MonoBehaviour
{
    private int currentHealth;


    // Sağlık değiştiğinde çağrılacak method
    public void LoseLife()
    {
        currentHealth -= 1;

        // Event'i yayınla
        EventBus.Publish(new HealthChangedEvent(currentHealth));
    }
}
