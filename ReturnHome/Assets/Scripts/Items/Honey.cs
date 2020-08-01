using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : Item
{
    public float AddAmountHP;
    public override void Update()
    {
        base.Update();
        interaction();
    }

    public Honey()
    {
        aresol = false;
        usesLeft = 1;
        myName = "Honey";
        description = "It tastes sweet.";
        type = "Consumable";
    }

    public override void OnUse()
    {
        FindObjectOfType<PlayerController>().DecreaseHealth(-AddAmountHP);
        if (FindObjectOfType<PlayerController>().gameObject.GetComponentInChildren<IllEffect>())
        { 
            FindObjectOfType<PlayerController>().gameObject.GetComponentInChildren<IllEffect>().EndEffect();//delete the add the "ill" effect to the player(?)
        }
        base.OnUse();
    }

}
