using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class IllnessGhostScript : GeneralGhost
{
    //public GameObject Skill;
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
        playerController.DecreaseHealth(0.5f);

       // Debug.log(PlayerController.Health);

        yield return new WaitForSeconds(1.0f);
        attacking = false;

        StopCoroutine(AttackOvertime());
    }
}
