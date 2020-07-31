using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixDown : Item
{
    public float AddAmountHP;

    PlayerController Player;

    public PhoenixDown()
    {
        aresol = false;
        usesLeft = 1;
        myName = "Phoenix Down";
        description = "Revives";
        type = "Consumable";
    }

    public override void Update()
    {
        interaction();
        Player = FindObjectOfType<PlayerController>();
        if (Player.health <= 0)
        {
            Player.DecreaseHealth(-AddAmountHP);
            if (Player.gameObject.GetComponent<StatusEffect>())
            {
                Destroy(Player.gameObject.GetComponent<StatusEffect>());
            }
            if (Player.gameObject.GetComponent<IllEffect>())
            {
                Destroy(Player.gameObject.GetComponent<IllEffect>());
            }
        }
        base.Update();
    }
}
