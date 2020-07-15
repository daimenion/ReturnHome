using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class IllnessGhostScript : GeneralGhost
{
    //public GameObject Skill;
    protected override void Awake()
    {
        MaxHealth = 75;
        base.Awake();


    }
    public override void Attack()
    {
        if(attacking == false)
        {
            attacking = true;
            //Skill.SetActive(true);
            //Skill.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            StartCoroutine(AttackOvertime());
        }
    }

    IEnumerator AttackOvertime()
    {
        yield return new WaitForSeconds(0.5f);
        playerController.PlayerDecreaseHealth(2f,"Ghost");

       // Debug.log(PlayerController.Health);

        yield return new WaitForSeconds(1.0f);
        attacking = false;

        StopCoroutine(AttackOvertime());
    }
}
