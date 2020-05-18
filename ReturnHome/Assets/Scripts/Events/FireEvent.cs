using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : EventController
{ //Sets the player on fire.
    protected override void EventStay(Collider other)
    {
        if (other.gameObject.GetComponent<FireEffect>() == null)
        {
            other.gameObject.AddComponent<FireEffect>();
        }
        else
        {
            other.gameObject.GetComponent<FireEffect>().Reset();
        }
    }

}
