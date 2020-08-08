using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    //public boolean to check if it's being used, can change to private later
    public bool IsUsed;
    public ParticleSystem particles;
    public GameObject particle;
    // Update is called once per frame
    public override void Update()
    {
        interaction();
        base.Update();
        if (Input.GetButtonUp("UseItem"))
        {
            particles.Play();
        }
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

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided");
        if (other.tag == "Ghost")
        {
            other.GetComponent<AI>().DecreaseHealth(damage);

        }

    }
    public override void OnUse()
    {
        base.OnUse();
        particles.Stop();
        particles.Emit(1);

    }
}
