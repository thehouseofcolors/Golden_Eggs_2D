using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EggType { Regular, Golden}
public abstract class Egg : MonoBehaviour
{
    public EggType eggType { get; protected set; }
    public int eggScore { get; protected set; }

    public int damage {  get; protected set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        HandleCollision(collision);
    }

    private void HandleCollision(Collider2D collider)
    {
        if (collider.CompareTag("Ground"))
        {
            PoolManager.Instance.ReAssignEgg(gameObject);
            DecreaseHealth(damage);
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
