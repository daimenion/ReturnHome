using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : Weapon
{
    public override void Update()
    {
        base.Update();
        interaction();
    }
    public BaseballBat()
    {
        meleeRot = new Vector3(0, 45, -45);
        aresol = false;
        usesLeft = -1;
        myName = "BaseballBat";
        description = "HOME RUN!!!";
        type = "Weapon";
        damage = 6.0f;
    }

}
