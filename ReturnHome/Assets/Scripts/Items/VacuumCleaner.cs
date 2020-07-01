using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : Weapon
{
    public float pullForceX;
    public float pullForceZ;
    public float range;
    public float baseDmg;
    public float increasedDmg; //damage when modified
    public bool isModified;

    void Update()
    {
        interaction();
    }

    public VacuumCleaner()
    {
        aresol = true; //Get button down(?)
        usesLeft = 6;
        myName = "Vacuum Cleaner";
        description = "Pull the ghost's closer to you.";
        type = "Cleaning tool"; //(?)
        damage = 0.3f;
    }

    public override void OnUse()
    {
        base.OnUse();
        StartCoroutine(Using());
    }

    IEnumerator Using()
    {
        GeneralGhost[] ghosts = GameObject.FindObjectsOfType<GeneralGhost>();

        foreach (GeneralGhost ghost in ghosts)
        {
            if (Vector3.Distance(ghost.transform.position, this.transform.position) <= range)    //Adjust the range
            {
                yield return new WaitForSeconds(0.2f);

                //Deal damage to ghost

                ghost.GetComponent<Rigidbody>().AddForce (new Vector3
                    (FindObjectOfType<GeneralGhost>().speed * pullForceX, 0, 
                    FindObjectOfType<GeneralGhost>().speed * pullForceZ));
                Debug.Log("Pulling ghost in");
            }
        }
        StopCoroutine(Using());
    }
}
