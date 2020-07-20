using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireExtinguisher : Weapon
{
    public ParticleSystem particles;
    public GameObject particle;
    void Update()
    {
        base.Update();
        interaction();
        if (Input.GetButtonUp("UseItem"))
        {
            particle.SetActive(false);
        }
    }
    public FireExtinguisher() {
        aresol = true;
        usesLeft = 10;
        myName = "Fire Extinguisher";
        description = "The enemy of fire . . . you got a wild Fire Extinguisher";
        type = "Weapon";
        damage = 0.5f;
    }
    void OnTriggerStay(Collider other) {


    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided");
        if (other.tag == "Ghost") {
            other.GetComponent<AI>().DecreaseHealth(0.1f);

        }

    }
    void OnParticleTrigger() { 
    
    }
    public override void OnUse()
    {
        base.OnUse();
        particle.SetActive(true);
        particles.Emit(1);

    }
}
