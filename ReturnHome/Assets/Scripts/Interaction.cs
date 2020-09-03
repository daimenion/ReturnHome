using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interaction : MonoBehaviour//This will eventually be an abstract class when it stops being used in an example prefab
{
    protected bool inRange;
    private GameObject canvas;
    public bool Interacted;
    virtual protected void Start()
    {
        canvas = gameObject.transform.Find("Canvas").gameObject;
        if (canvas == null) print(gameObject.name);
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
        if (other.tag == "Player" && !Interacted){
        canvas.SetActive(true);
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
            Interacted = false;
        }
    }
     virtual protected void myInteraction()
    {
        print("Interact");
        Interacted = true;
    }
}
