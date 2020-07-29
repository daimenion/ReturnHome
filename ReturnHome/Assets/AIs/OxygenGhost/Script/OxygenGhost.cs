using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class OxygenGhost : GeneralGhost
{
    public GameObject Skill;
    protected override void Awake()
    {
        MaxHealth = 75;
        base.Awake();
        

    }
    public override void Attack()
    {
        if (attacking == false)
        {

            base.Attack();
            playerController.oxygen -= 0.5f;
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
