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
    public ViewCircle view;

    public override void Update()
    {
        base.Update();
        interaction();
    }

    public VacuumCleaner()
    {
        aresol = true; //Get button down(?)
        usesLeft = 20;
        myName = "Vacuum Cleaner";
        description = "Pull the ghost's closer to you.";
        type = "Cleaning tool"; //(?)
        damage = 0.3f;
        //view = transform.GetComponentInChildren<ViewCircle>();
    }

    public override void OnUse()
    {
        base.OnUse();
 
        Using();
    }

     void Using()
    {
        GeneralGhost[] ghosts = GameObject.FindObjectsOfType<GeneralGhost>();

        foreach (GeneralGhost ghost in ghosts)
        {
            if (view.visibleTargets.Contains(ghost.gameObject.transform))    //Adjust the range
            {
                //yield return new WaitForSeconds(0.2f);

                //Deal damage to ghost
                ghost.DecreaseHealth(0.01f);
                //ghost.GetComponent<Rigidbody>().AddForce (new Vector3
                //    (FindObjectOfType<GeneralGhost>().speed * pullForceX, 0, 
                //    FindObjectOfType<GeneralGhost>().speed * pullForceZ));
                Vector3 windowPosition = new Vector3(transform.position.x, ghost.transform.position.y, transform.position.z);
                ghost.transform.position = Vector3.MoveTowards(ghost.transform.position, transform.position, 0.1f);
                Debug.Log("Pulling ghost in");
            }

        }
        //StopCoroutine(Using());
    }
}
