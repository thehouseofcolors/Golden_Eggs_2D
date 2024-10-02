using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Egg : MonoBehaviour
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
    
    public void OnGroundHit()
    {
        // Logic when the egg hits the ground, e.g., deactivate or reset position
        EggPoolManager eggPoolManager = FindObjectOfType<EggPoolManager>();
        eggPoolManager.AssignEggToRandomChicken(this);
    }


    public EggType GetEggType() => type;
    public int GetEggScore() => eggScore;
    public float GetEggSpeed() => eggSpeed;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the egg has collided with the ground
        if (collision.gameObject.CompareTag("Ground")) // Make sure your ground has the tag "Ground"
        {
            OnGroundHit();  
        }
    }


}
