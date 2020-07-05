using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGhost : GeneralGhost
{
    [SerializeField] private GameObject Ghost;
    int numberOfGhost;
    GameObject[] SmallGhost;
    protected override void Awake()
    {
        SmallGhost = new GameObject[2];
        MaxHealth = 75;
        base.Awake();


    }
    public override void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            base.Attack();
            StartCoroutine(spawnGhost());
        }
    }

    IEnumerator spawnGhost()
    {

        yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < SmallGhost.Length ; i++)
            {
                if (SmallGhost[i] == null)
                {
                    GameObject a = Instantiate(Ghost, new Vector3(this.transform.localPosition.x + 2, 0, this.transform.localPosition.z + 2), Quaternion.identity);
                    SmallGhost[i] = a;
                }
            }


        yield return new WaitForSeconds(0.5f);

        attacking = false;
        StopCoroutine(spawnGhost());

    }
}
