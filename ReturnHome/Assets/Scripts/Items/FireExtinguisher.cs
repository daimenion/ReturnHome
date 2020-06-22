using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireExtinguisher : Weapon
{
    public GameObject particle;
    void Update()
    {
        base.Update();
        interaction();
        if (Input.GetButtonUp("UseItem"))
        {
            particle.SetActive(false);
        }
    }
    public FireExtinguisher() {
        aresol = true;
        usesLeft = 10;
        myName = "Fire Extinguisher";
        description = "The enemy of fire . . . you got a wild Fire Extinguisher";
        type = "Weapon";
        damage = 5.0f;
    }
    void OnTriggerStay(Collider other) {


    }
    public override void OnUse()
    {
        base.OnUse();
        particle.SetActive(true);

    }
}
