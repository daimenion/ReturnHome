﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : EventController
{ //Sets the player on fire.
    float fireHealth = 100;
    float fireMax = 100;
    private ParticleSystem particle;
    new void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    protected override void EventStay(Collider other)
    {
        if (other.GetComponent<PlayerController>()) {
            if (other.gameObject.GetComponentInChildren<FireEffect>() == null)
            {
                other.GetComponent<PlayerController>().AddEffect("On Fire!");
            }
            else
            {
                other.gameObject.GetComponentInChildren<FireEffect>().Reset();
            }
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
        particle.startSize = fireHealth / fireMax;
        if (fireHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
