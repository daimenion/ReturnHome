﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    void Update()
    {
        interaction();

    }
    public Knife()
    {
        aresol = false;
        usesLeft = -1;
        myName = "Knife";
        description = "Let me see what you have...";
        type = "Weapon";
        damage = 5.0f;
    }
}