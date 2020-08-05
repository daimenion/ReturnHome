using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAll : Item
{
    public float AddAmountHP;
    public override void Update()
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
        if (FindObjectOfType<PlayerController>().gameObject.GetComponentInChildren<IllEffect>())
        {
            FindObjectOfType<PlayerController>().gameObject.GetComponentInChildren<StatusEffect>().EndEffect(); //Well now it's public, so
            //Destroy(FindObjectOfType<PlayerController>().gameObject.GetComponent<StatusEffect>());//delete the add the "ill" effect to the player(?)
        }
        base.OnUse();
    }

}
