using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeReturner : Item
{
    public GameObject player;
    public Vector3 homeLocation;
    void Update()
    {
        interaction();
    }
    public HomeReturner()
    {
        aresol = false;
        usesLeft = 3.0f;
        myName = "HomeReturner";
        description = "Feels good to be back home";
        type = "Consumable";
    }

    public override void OnUse()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = homeLocation;
        base.OnUse();
    }
}
