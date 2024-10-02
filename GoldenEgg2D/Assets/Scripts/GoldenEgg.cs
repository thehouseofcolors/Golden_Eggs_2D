using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenEgg : Egg
{
    public override void Initialize()
    {
        type = EggType.Golden; // Specific to RegularEgg
        eggScore = 10;           // Specific score for RegularEgg
        eggSpeed = 3.0f;       // Specific speed for RegularEgg
    }
}
