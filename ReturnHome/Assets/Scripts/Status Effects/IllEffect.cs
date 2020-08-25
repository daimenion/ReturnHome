using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllEffect : StatusEffect
{
    public float Illdmg;
    public IllEffect()
    {
        duration =10;
        effectName = "Ill";
        effectDescription = "That caffeteria food seemed a little off...";
        Illdmg = 1.2f;
    }

}
