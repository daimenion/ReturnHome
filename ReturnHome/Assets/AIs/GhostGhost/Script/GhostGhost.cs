using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGhost : GeneralGhost
{
    [SerializeField] private GameObject Ghost;

    public override void Attack()
    {
        if (attacking)
        {
            Instantiate(Ghost, this.transform);
            base.Attack();
        }
    }
}
