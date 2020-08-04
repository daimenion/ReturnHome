using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class FireGhost : GeneralGhost
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
            Skill.SetActive(true);
            Skill.GetComponent<ParticleSystem>().Play();
            Skill.GetComponent<ParticleSystem>().Emit(1);
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
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    //    if (other.CompareTag("Player"))
    //    {
    //        playerController.PlayerDecreaseHealth(10.0f, "Ghost");
    //    }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerController.PlayerDecreaseHealth(0.001f, "Ghost");
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {

    //    }
    //}

}
