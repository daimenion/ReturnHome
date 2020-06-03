using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGhost : GeneralGhost
{
    [SerializeField] private GameObject Ghost;

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
        Instantiate(Ghost, new Vector3(this.transform.localPosition.x + 2, 0, this.transform.localPosition.z + 2), Quaternion.identity);
        Instantiate(Ghost, new Vector3(this.transform.localPosition.x - 2, 0, this.transform.localPosition.z - 2), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        attacking = false;
        StopCoroutine(spawnGhost());

    }
}
