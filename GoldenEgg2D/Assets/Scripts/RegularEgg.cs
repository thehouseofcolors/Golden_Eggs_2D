using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEgg : Egg
{
    private void Awake()
    {
        eggType = EggType.Regular;
        eggScore = 1;
        demage = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        HandleCollision(collision);
    }

    private void HandleCollision(Collider2D collider)
    {
        if (collider.CompareTag("Ground"))
        {
            PoolManager.Instance.ReAssignEgg(gameObject);
            DecreaseHealth(demage);
        }
        else if (collider.CompareTag("Player"))
        {
            PoolManager.Instance.ReAssignEgg(gameObject);
            AddScore(eggScore);
        }

    }



    
    public void AddScore(int amount)
    {
        UIControl.Instance.ChangeScore(amount);
    }

    public void DecreaseHealth(int amount)
    {
        UIControl.Instance.ChangeHealth(amount);
    }


}
