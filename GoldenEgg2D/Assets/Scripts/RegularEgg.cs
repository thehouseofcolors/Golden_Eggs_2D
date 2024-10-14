using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEgg : Egg
{
    [SerializeField] private GameData gameData;
    private void Awake()
    {
        eggType = EggType.Regular;
        eggScore = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { PoolManager.Instance.ReAssignEgg(gameObject); DecreaseHealth(1); }
        else if (collision.gameObject.CompareTag("Player")) { AddScore(eggScore);  }
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
