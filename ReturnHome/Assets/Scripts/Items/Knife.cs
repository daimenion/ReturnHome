﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    public override void Update()
    {
        base.Update();
        interaction();
    }
    public Knife()
    {
        meleeRot = new Vector3(0, 0, -45);
        aresol = false;
        usesLeft = -1;
        myName = "Knife";
        description = "Let me see what you have...";
        type = "Weapon";
        damage = 5.0f;
    }

}
