using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hairspray : Weapon
{
    //public boolean to check if it's being used, can change to private later
    public bool IsUsed;
    public ParticleSystem particles;
    public GameObject particle;
    void Update() {
        interaction();
        if (Input.GetButtonUp("UseItem"))
        {
            particle.SetActive(false);
        }
    }
    public Hairspray()
    {
        aresol = true;
        usesLeft = 30.0f;
        myName = "Hairspray";
        description = "Good Morning Baltimore!";
        type = "Hair Product";
        damage = 0.5f;
    }

    public override void OnUse()
    {
        IsUsed = !IsUsed;
        base.OnUse();
        particle.SetActive(true);
        particles.Emit(1);
    }

    public void OnTriggerEnter(Collider other)
    {
        //If inside the hitbox, item is used, and other object is an enemy
        if(WeaponHitBox.bounds.Intersects(other.bounds) && IsUsed && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Do damage to other object

        }
    }


}
