using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : StatusEffect
{
    private float damage;
    public FireEffect()
    {
        duration = 7f;
        effectName = "On Fire!";
        effectDescription = "You're on fire! It's pretty self-explanitory.";
        damage = 4f;
    }
    new void Update()
    {
        base.Update();
        FindObjectOfType<PlayerController>().PlayerDecreaseHealth(damage * Time.deltaTime,"Fire");
    }
    public new void Reset()
    {
        duration = 7f;
    }
}
