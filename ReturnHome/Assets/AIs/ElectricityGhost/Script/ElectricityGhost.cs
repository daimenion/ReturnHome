using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ElectricityGhost : GeneralGhost
{
    public GameObject Skill;
    protected override void Awake()
    {
        MaxHealth = 75;
        base.Awake();
        AttackDamage = 5.0f;

    }
    public override void Attack()
    {
        if (attacking == false)
        {

            base.Attack();
            playerController.Electrocute(AttackDamage);
            StartCoroutine(reset());
            attacking = true;
            
        }
        
    }
    IEnumerator reset() {

        yield return new WaitForSeconds(0.0f);
        attacking = false;
        StopCoroutine(reset());
    }

}
