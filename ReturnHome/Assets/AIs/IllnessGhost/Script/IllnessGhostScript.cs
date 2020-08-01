using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class IllnessGhostScript : GeneralGhost
{
    LineRenderer line;
    GameObject lineStart;
    GameObject lineEnd;
    Vector3 endPosition;
    //public GameObject Skill;
    protected override void Awake()
    {
        MaxHealth = 75;
        base.Awake();
        AttackDamage = 2.0f;

    }
    protected override void Update()
    {
        base.Update();
        if (attacking)
        {
            endPosition.x = lineEnd.transform.localPosition.x;
            endPosition.z = lineEnd.transform.localPosition.z;
            line.SetPosition(1, endPosition);

        }
        if (CurrentState != States.Attack) {
            endPosition.x = lineStart.transform.localPosition.x;
            endPosition.z = lineStart.transform.localPosition.z;
            line.SetPosition(1, endPosition);
        }

    }
    public override void Attack()
    {
        lineStart = this.gameObject;
        lineEnd = playerController.gameObject;
        line = transform.GetComponentInChildren<LineRenderer>();
        Vector3 startPosition = new Vector3(lineStart.transform.localPosition.x, 1.75f, lineStart.transform.localPosition.z);
        line.SetPosition(0, startPosition);
        endPosition = new Vector3(lineEnd.transform.localPosition.x, 1.75f, lineEnd.transform.localPosition.z);

        if (attacking == false)
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
        if (playerController.gameObject.GetComponentInChildren<IllEffect>())
        {
            AttackDamage = AttackDamage * playerController.gameObject.GetComponentInChildren<IllEffect>().Illdmg;
        }
        playerController.PlayerDecreaseHealth(AttackDamage,"Ghost");

       // Debug.log(PlayerController.Health);

        yield return new WaitForSeconds(1.0f);
        attacking = false;

        StopCoroutine(AttackOvertime());
    }
}
