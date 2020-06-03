using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowOxygenEffect : StatusEffect
{
    public LowOxygenEffect() {
        duration = -1;
        effectName = "Low Oxygen";
        effectDescription = "YOU NEED AIR!!!!";
        if (GetComponent<PlayerController>().LowOxygen)
        {
            GetComponent<PlayerController>().speed = 5;
            //add visual stuff
        }
    }

}
