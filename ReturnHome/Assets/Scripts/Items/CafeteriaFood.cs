using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeteriaFood : Item
{
    void Update()
    {
        interaction();

    }
    public CafeteriaFood()
    {
        aresol = false;
        usesLeft = 1;
        myName = "Cafeteria Food";
        description = "Its probably better than starving... Probably.";
        type = "Consumable";
    }
    new void OnUse()
    {
        base.OnUse();
        GetComponent<PlayerController>().DecreaseHealth(-10f);
        if (Random.Range(0, 5) == 0)
        {
            gameObject.AddComponent<IllEffect>(); //add the "ill" effect to the player
        }
    }

}