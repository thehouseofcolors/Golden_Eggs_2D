using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEgg : Egg
{
    private void Awake()
    {
        eggType = EggType.Regular;
        eggScore = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PoolManager.Instance.ReAssignEgg(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
