using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public enum eventEnum { NotSet,Fire,WetFloor}
    public eventEnum eventType;
    private Collider range;
    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (eventType)
        {
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            switch (eventType)
            {
                case eventEnum.Fire:
                    //add "on Fire!" to player if not already there
                    break;
                case eventEnum.WetFloor:
                    //Small chance for the player to trip
                    break;
                default:
                    break;
            }
        }
    }
}
