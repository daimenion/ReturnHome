using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : EventController
{ //Sets the player on fire.
    float fireHealth = 100;
    float fireMax = 100;
    protected override void EventStay(Collider other)
    {
        if (other.gameObject.GetComponent<FireEffect>() == null)
        {
            other.gameObject.AddComponent<FireEffect>();
        }
        else
        {
            other.gameObject.GetComponent<FireEffect>().Reset();
        }
    }
    void OnParticleCollision(GameObject other)
    {
        Item item = other.transform.parent.GetComponent<Item>();
        if (item.myName == "Fire Extinguisher")
        {
            fireHealth -= 3;
        }
        else if (item.myName == "Hairspray" || item.myName == "Flamethrower")
        {
            Mathf.Min(fireHealth + 3, fireMax);
        }

        if (fireHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
