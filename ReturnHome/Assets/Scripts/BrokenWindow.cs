using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject room;
    private Collider roomCollider;
    private GameObject player;
    private Rigidbody playerBody;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerBody = player.GetComponent<Rigidbody>();
        room = transform.parent.gameObject;
        while (room.tag != "Room")
        {
            room = room.transform.parent.gameObject;
        }
        roomCollider = room.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roomCollider.bounds.Contains(player.transform.position)) 
        {
            Vector3 windowPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            //playerBody.AddForce((windowPosition - player.transform.position)*0.4f,ForceMode.Force);
            player.transform.position = Vector3.MoveTowards(player.transform.position, windowPosition, 0.02f);
        }
    }
    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject == player)
        {
            player.GetComponent<PlayerController>().PlayerDecreaseHealth(100, "SuckIntoSpace"); //Whatever the code for getting sucked into space is
            print("Kill");
        }
    }

}
