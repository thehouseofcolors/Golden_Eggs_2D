using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EggType { Regular, Golden}
public abstract class Egg : MonoBehaviour
{
    public EggType eggType { get; protected set; }
    public int eggScore { get; protected set; }

    public int demage {  get; protected set; }

}
