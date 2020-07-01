using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravityEvent : EventController
{
    //TO DO
    //Make event only begin when player enters and exits area
    //Make it affect all objects in the room
    protected override void EventStay(Collider other)
    {
        
        if(other.gameObject.GetComponent<Rigidbody>())
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
