using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAll : Item
{
    public float AddAmountHP;
    void Update()
    {
        interaction();
    }

    public CureAll()
    {
        aresol = false;
        usesLeft = 1;
        myName = "Cure-All";
        description = "It cures all!";
        type = "Consumable";
    }

    public override void OnUse()
    {
        FindObjectOfType<PlayerController>().DecreaseHealth(-AddAmountHP);
        if (FindObjectOfType<PlayerController>().gameObject.GetComponent<IllEffect>())
        {
            //FindObjectOfType<PlayerController>().gameObject.GetComponent<StatusEffect>().EndEffect(); //EndEffect needs to public in order to deletethis.
            Destroy(FindObjectOfType<PlayerController>().gameObject.GetComponent<StatusEffect>());//delete the add the "ill" effect to the player(?)
        }
        base.OnUse();
    }

}
