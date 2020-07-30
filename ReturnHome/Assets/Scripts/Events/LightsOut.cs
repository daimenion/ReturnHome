using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : EventController
{ //Sets the player on fire.
    public Light light;
    Quaternion oriRotat;
    public override void Start()
    {
        base.Start();
        light = GameObject.Find("Directional Light").GetComponent<Light>();
        oriRotat = light.gameObject.transform.rotation;
    }
    protected override void EventStay(Collider other)
    {
       
        light.gameObject.transform.rotation = new Quaternion(200, -30, 0,1);
    }
    private void OnTriggerExit(Collider other)
    {
            light.gameObject.transform.rotation = oriRotat;
    }

}
