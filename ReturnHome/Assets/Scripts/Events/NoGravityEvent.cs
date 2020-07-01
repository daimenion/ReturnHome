using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravityEvent : EventController
{
    protected override void EventStay(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>())
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
