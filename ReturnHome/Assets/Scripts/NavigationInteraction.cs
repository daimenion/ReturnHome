using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationInteraction : Interaction
{
    private CustomGameManager gameManager;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<CustomGameManager>();
    }
    override protected void myInteraction()
    {
        float health = gameManager.GetShipHealth();
        if (health >= gameManager.MaxShipHealth*0.80)
        {
            print("Congrats, you returned home.");
        }
    }
}
