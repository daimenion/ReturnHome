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
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (eventType)
            {
                case eventEnum.Fire:
                    if (other.gameObject.GetComponent<FireEffect>() == null) {
                        other.gameObject.AddComponent<FireEffect>();
                    }
                    else
                    {
                        other.gameObject.GetComponent<FireEffect>().Reset();
                    }
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
