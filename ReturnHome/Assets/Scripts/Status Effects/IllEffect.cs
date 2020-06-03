using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllEffect : StatusEffect
{
    float Illdmg;
    public IllEffect()
    {
        duration = -1;
        effectName = "Ill";
        effectDescription = "You are sick, you need to see a doctor";
        Illdmg = 1.2f;
    }

}
