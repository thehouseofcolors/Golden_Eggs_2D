using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EggType { Regular, Golden}


public struct Egg
{
    public EggType eggType;
    public int eggScore;

    public int damage;
    public Egg(EggType type, int score, int damage)
    {
        eggType = type;
        eggScore = score;
        this.damage = damage;
    }
}
public class EggController : MonoBehaviour
{
    private Egg egg;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        HandleCollision(collision);
    }

    private void HandleCollision(Collider2D collider)
    {

    }
    public void AddScore(int amount)
    {
        
    }

    public void DecreaseHealth(int amount)
    {
        
    }
}
