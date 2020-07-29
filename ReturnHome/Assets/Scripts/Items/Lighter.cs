using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lighter : Item
{
    public Light light;

    private bool useLight;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        interaction();
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            light.intensity = 0;
        }
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
        useLight = true;
        if (Equipped && useLight)
        {
            light.intensity = 10;
            base.OnUse();
        }
        base.OnUse();
    }

}
