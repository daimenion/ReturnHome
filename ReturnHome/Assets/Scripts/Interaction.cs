using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interaction : MonoBehaviour
{
    private Collider range;
    protected bool inRange;
    void Start()
    {
        range = GetComponent<Collider>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            myInteraction();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
    void myInteraction()
    {
        print("The object has been interacted with");
    }
}
