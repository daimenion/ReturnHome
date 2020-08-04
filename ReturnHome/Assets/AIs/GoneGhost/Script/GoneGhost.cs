using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoneGhost : GeneralGhost
{
    public float TeleportInterval;
    public float BehindPlayerOffset;
    float tpCoolDown;
    bool hit;
    protected override void Awake()
    {
        MaxHealth = 25;
        base.Awake();
    }

    //Teleport using a coroutine
    IEnumerator TeleportAround()
    {
        Vector3 randpos = randompos();
        yield return new WaitForSeconds(TeleportInterval);
        //get random value
        Debug.Log("Starting coroutine");
        //switch(Random.Range(1,3))
        //{
        //    //case 1://Teleport behind player and teleport them to a random spot


        //    //    break;

        //    case 1:  //Teleport to random part of ship
                Teleport(randpos.x, transform.position.y, randpos.z);
                Debug.Log("teleported random1");
        //    break;

        //case 2:
        //    Teleport(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
        //    Debug.Log("teleported random2");
        //    break;

        //default:
        //    break;

        // }
    }

    Vector3 randompos() {
        RandomPosition = this.transform.position + UnityEngine.Random.insideUnitSphere * wanderingRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(RandomPosition, out hit, wanderingRadius, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }
    public override void Attack()
    {
        if (attacking == false)
        {
            Teleport(playerController.transform.position.x - BehindPlayerOffset, playerController.transform.position.y, playerController.transform.position.z);
            Debug.Log("teleported behind");
            StartCoroutine(MovePlayer());
        }

    }
    private void Teleport(float x, float y, float z)
    {
        transform.position = new Vector3(x,y,z);
    }

    public override void MoveForward()
    {
        tpCoolDown++;
        if (tpCoolDown >= 180)
        {
            StartCoroutine(TeleportAround());
            tpCoolDown = 0;
        }
        //base.MoveForward();
    }

    IEnumerator MovePlayer()
    {
        hit = GetHit();
        Vector3 randpos = randompos();
        if (!hit)
        {
            yield return new WaitForSeconds(TeleportInterval);
            Debug.Log("moved player");
            playerController.transform.position = new Vector3(randpos.x, playerController.transform.position.y, randpos.z);
            transform.position = new Vector3(randpos.x, transform.position.y, randpos.z);
            StopCoroutine(MovePlayer());
        }
    }
}
