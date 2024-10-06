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
}
