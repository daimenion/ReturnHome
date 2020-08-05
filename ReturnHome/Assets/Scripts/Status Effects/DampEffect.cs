using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampEffect : StatusEffect
{
    public DampEffect()
    {
        duration = 20f;
        effectName = "Damp";
        effectDescription = "In space, no-one can see you shiver.";
    }
    public new void Reset()
    {
        duration = 20f;
    }
}
