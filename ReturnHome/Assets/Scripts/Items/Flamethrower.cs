using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    //public boolean to check if it's being used, can change to private later
    public bool IsUsed;
    // Update is called once per frame
    public override void Update()
    {
        interaction();
        base.Update();
    }

    public Flamethrower()
    {
        aresol = false;
        usesLeft = 30.0f;
        myName = "Flamethrower";
        description = "Light em up!";
        type = "Weapon";
        damage = 15.0f;
    }

    public void OnTriggerEnter(Collider other)
    {
        //If inside the hitbox, item is used, and other object is an enemy
        if (WeaponHitBox.bounds.Intersects(other.bounds) && IsUsed && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Do damage to other object

        }
    }
}
