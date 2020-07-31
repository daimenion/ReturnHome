using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : EventController
{ //Sets the player on fire.
    public Light light;
    Color render;
    Material sky; 
    Quaternion oriRotat;
    public override void Start()
    {
        base.Start();
        light = GameObject.Find("Directional Light").GetComponent<Light>();
        oriRotat = light.gameObject.transform.rotation;
        sky = RenderSettings.skybox;
        render = RenderSettings.ambientLight;
    }
    protected override void EventStay(Collider other)
    {
       
        light.gameObject.transform.rotation = new Quaternion(200, -30, 0,1);
        RenderSettings.ambientLight = Color.black;
        //RenderSettings.reflectionIntensity = 0;
        RenderSettings.skybox = null;
    }
    private void OnTriggerExit(Collider other)
    {
        light.gameObject.transform.rotation = oriRotat;
        RenderSettings.ambientLight = render;
        //RenderSettings.reflectionIntensity = 1;
        RenderSettings.skybox = sky;
    }

}
