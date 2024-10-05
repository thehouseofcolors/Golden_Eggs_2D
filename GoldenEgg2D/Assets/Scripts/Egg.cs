using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Egg : MainManager
{
    protected EggType type;
    protected int eggScore;
    protected float eggSpeed;
    
    public enum EggType { Regular, Golden, Diamond }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
        Initialize();
    }

    public abstract void Initialize();
    
    


    public EggType GetEggType() => type;
    public int GetEggScore() => eggScore;
    public float GetEggSpeed() => eggSpeed;

    public void OnGroundHit()
    {

    }


    public void EggCaught()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            OnGroundHit();
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EggCaught();
        }
    }
}
