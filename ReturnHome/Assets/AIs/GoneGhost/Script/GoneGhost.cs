using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneGhost : GeneralGhost
{
    public float TeleportInterval;
    public float BehindPlayerOffset;
    protected override void Awake()
    {
        MaxHealth = 25;
        base.Awake();
    }

    //Teleport using a coroutine
    IEnumerator TeleportAround()
    {
        yield return new WaitForSeconds(TeleportInterval);
        //get random value
        Debug.Log("Starting coroutine");
        switch(Random.Range(1,3))
        {
            case 1://Teleport behind player and teleport them to a random spot
                Teleport(playerController.transform.position.x - BehindPlayerOffset, playerController.transform.position.y, playerController.transform.position.z);
                Debug.Log("teleported behind");
                StartCoroutine(MovePlayer());

                break;

            case 2:  //Teleport to random part of ship
                Teleport(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
                Debug.Log("teleported random1");
                break;

            case 3:
                Teleport(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
                Debug.Log("teleported random2");
                break;

            default:
                break;
        }
    }
    
    private void Teleport(float x, float y, float z)
    {
        transform.position = new Vector3(x,y,z);
    }

    public override void MoveForward()
    {
        StartCoroutine(TeleportAround());
        base.MoveForward();
    }

    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(TeleportInterval);
        Debug.Log("moved player");
        playerController.transform.position = transform.position - new Vector3(BehindPlayerOffset, 0, 0);
        StopCoroutine(MovePlayer());
    }
}
