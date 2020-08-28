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
        base.Update();
        Player = FindObjectOfType<PlayerController>();
        if (transform.parent != null)
        {
            if (Player.health <= 3)
            {
                NewOnUse();
            }
        }
    }
    public void NewOnUse()
    {
        Player.DecreaseHealth(-AddAmountHP);
        if (Player.transform.GetComponentsInChildren<StatusEffect>().Length!= 0)
        {
            for (int i = 0; i < Player.transform.GetComponentsInChildren<StatusEffect>().Length; i++)
            {
                Player.transform.GetComponentsInChildren<StatusEffect>()[i].EndEffect();
            }
        }

        base.OnUse();
        Destroy(this.gameObject);
    }
}
