using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class FireGhost : GeneralGhost
{
    public GameObject Skill;
    public override void Attack()
    {
        if (attacking == false)
        {
            Skill.SetActive(true);
            Skill.GetComponent<ParticleSystem>().Play();
            base.Attack();
            StartCoroutine(reset());
            attacking = true;
        }
        
    }
    IEnumerator reset() {

        yield return new WaitForSeconds(5.0f);
        Skill.SetActive(false);
        Skill.GetComponent<ParticleSystem>().Stop();

        yield return new WaitForSeconds(2.0f);
        attacking = false;
        StopCoroutine(reset());
    }

}
