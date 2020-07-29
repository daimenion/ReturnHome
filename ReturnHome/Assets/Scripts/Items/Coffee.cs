using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Item
{
    public PlayerController pController;
    public float effectiveTime;
    public int newSpeed;

    void Update()
    {
        interaction();
    }
    public Coffee()
    {
        aresol = true;
        usesLeft = 30.0f;
        myName = "Coffee";
        description = "For those Monday mornings";
        type = "Consumable";

    }

    public override void OnUse()
    {
        if(!pController)
        {
            pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        pController.bCoffee = true;
        pController.StartCoroutine(pController.Coffee(effectiveTime, newSpeed));
        base.OnUse();
    }
}
