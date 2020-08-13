using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : Item
{
    public override void Update()
    {
        base.Update();
        interaction();
    }
    public Toy(){
        aresol = false;
        usesLeft = 1;
        myName = "Toy";
        description = "A TOY! wait . . . This and vacuum";
        type = "Tool";

    }
}
