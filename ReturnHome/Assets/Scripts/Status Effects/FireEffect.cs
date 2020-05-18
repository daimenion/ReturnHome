using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : StatusEffect
{
    private float damage;
    public FireEffect()
    {
        duration = 2.0f;
        effectName = "On Fire!";
        effectDescription = "You're on fire! It's pretty self-explanitory.";
        damage = 2.0f;
    }
    new void Update()
    {
        base.Update();
        gameObject.GetComponent<PlayerController>().DecreaseHealth(damage * Time.deltaTime);
    }
    public void Reset()
    {
        duration = 2.0f;
    }
}
