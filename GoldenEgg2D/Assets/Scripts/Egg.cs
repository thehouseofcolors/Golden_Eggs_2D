using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Egg : MonoBehaviour
{
    protected EggType type;
    protected int eggScore;
    protected float eggSpeed;
    protected ScoreManager scoreManager;
    
    public enum EggType { Regular, Golden, Diamond }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
        Initialize();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public abstract void Initialize();
    
    


    public EggType GetEggType() => type;
    public int GetEggScore() => eggScore;
    public float GetEggSpeed() => eggSpeed;

    public void OnGroundHit()
    {
        // Logic when the egg hits the ground, e.g., deactivate or reset position
        EggPoolManager eggPoolManager = FindObjectOfType<EggPoolManager>();
        eggPoolManager.ReAssignEgg(this);
    }
    public void EggCaught()
    {
        EggPoolManager eggPoolManager = FindObjectOfType<EggPoolManager>();
        eggPoolManager.ReAssignEgg(this);
        Debug.Log("egg caught");
        
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
            scoreManager.UpdateScore(GetEggScore());
        }
    }
}
