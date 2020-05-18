using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WireEvent : EventController
{//May trip the player, and may electrocute them if they are damp
    int tripChance = 80;// Chance player will trip over loose wire
    protected override void EventStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>().isMoving && Random.Range(0, tripChance) == 0)
        {
            //Player trips over wire and looses some health
            if (other.gameObject.GetComponent<DampEffect>())
            {
                //Player gets electrocuted as well.
            }
        }
    }
}
