using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    public override void Update()
    {
        base.Update();
        interaction();

    }
    public Rock()
    {
        meleeRot = new Vector3(0, 45, 135);
        aresol = false;
        usesLeft = -1;
        myName = "Rock";
        description = "Beats scissors.";
        type = "Weapon";
        damage = 2.0f;
    }
}
