using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lighter : Item
{
    public Light light;

    private bool useLight;

    // Update is called once per frame
    void Update()
    {
        interaction();
    }
    public Lighter()
    {
        aresol = false;
        usesLeft = 30.0f;
        myName = "Lighter";
        description = "Could use a cigarette.";
        type = "Lighter";

    }

    public override void OnUse()
    {
        if (!Equipped)
        {
            Equipped = true;
        }

        useLight = !useLight;
        if (Equipped && useLight)
        {
            light.intensity = 10;
            base.OnUse();

        }
        else
        {
            light.intensity = 0;
        }
        base.OnUse();
    }

}
