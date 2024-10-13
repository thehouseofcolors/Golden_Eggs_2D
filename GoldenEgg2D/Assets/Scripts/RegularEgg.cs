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
        if (collision.gameObject.CompareTag("Ground")) { PoolManager.Instance.ReAssignEgg(gameObject);}
        else if (collision.gameObject.CompareTag("Player")) { AddScore(eggScore);  }
    }
    
    public void AddScore(int amount)
    {
        gameData.CurrentScore += amount;
        UIControl.Instance.ChangeScore(amount); // Skoru güncelle
    }
}
