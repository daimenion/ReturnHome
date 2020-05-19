using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interaction : MonoBehaviour//This will eventually be an abstract class when it stops being used in an example prefab
{
    protected bool inRange;
    GameObject canvas;
    public bool Interacted;
    void Start()
    {
        canvas = gameObject.transform.Find("Canvas").gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            myInteraction();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        Interacted = false;
    }
    protected void myInteraction()
    {
        print("Interact");
        Interacted = true;
    }
}
