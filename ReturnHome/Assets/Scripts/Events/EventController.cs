using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
  abstract public class EventController : MonoBehaviour
{
    private Collider range;
    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            EventStay(other);
        }
    }
    abstract protected void EventStay(Collider other);
}