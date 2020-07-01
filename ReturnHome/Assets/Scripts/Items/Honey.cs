using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : Item
{
    public float AddAmountHP;
    void Update()
    {
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
        if (FindObjectOfType<PlayerController>().gameObject.GetComponent<IllEffect>())
        { 
            Destroy(FindObjectOfType<PlayerController>().gameObject.GetComponent<IllEffect>());//delete the add the "ill" effect to the player(?)
        }
        base.OnUse();
    }

}
