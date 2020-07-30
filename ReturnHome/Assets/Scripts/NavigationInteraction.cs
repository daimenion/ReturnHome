using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationInteraction : Interaction
{
    private CustomGameManager gameManager;
    private Animator anim;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<CustomGameManager>();
        anim = GetComponentInChildren<Animator>();
    }
    override protected void myInteraction()
    {
        float currentHealth = gameManager.GetShipHealth();
        if (currentHealth >= 1 && Interacted == false)
        {
            print("Congrats, you returned home.");
            anim.Play("Base Layer.Winscreen", 0, 0.25f);
            Interacted = true;
        }
        else print("Current:" + currentHealth + "  Max:" + 1);
    }
}
