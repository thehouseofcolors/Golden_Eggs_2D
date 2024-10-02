using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEgg : Egg
{
    public override void Initialize()
    {
        type = EggType.Regular; // Specific to RegularEgg
        eggScore = 1;           // Specific score for RegularEgg
        eggSpeed = 1.0f;       // Specific speed for RegularEgg
    }
}
