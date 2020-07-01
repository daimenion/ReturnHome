using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPack : Item
{
    public float AddAmountHP;
    void Update()
    {
        interaction();
    }

    public MedPack()
    {
        aresol = false;
        usesLeft = 1;
        myName = "Med Pack";
        description = "Heals the player, one time use";
        type = "Consumable";
    }

    public override void OnUse()
    {
        FindObjectOfType<PlayerController>().DecreaseHealth(-AddAmountHP);    
        base.OnUse();
    }

}
