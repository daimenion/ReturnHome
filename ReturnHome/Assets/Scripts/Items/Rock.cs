using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    void Update()
    {
        interaction();

    }
    public Rock()
    {
        aresol = false;
        usesLeft = -1;
        myName = "Knife";
        description = "Beats scissors.";
        type = "Weapon";
        damage = 1.0f;
    }
}
