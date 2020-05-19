using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hairspray : Weapon
{
    void Update() {
        interaction();
    
    }
    public Hairspray()
    {
        aresol = true;
        usesLeft = 30.0f;
        myName = "Hairspray";
        description = "Good Morning Baltimore!";
        type = "Hair Product";
        damage = 0.5f;
    }
}
