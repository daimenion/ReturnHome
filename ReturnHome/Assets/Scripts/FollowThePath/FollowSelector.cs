using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSelector : MonoBehaviour
{
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.localPosition;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            transform.parent.GetComponent<FollowThePath>().isActive = true;
        }
    }
    /*void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition) + initialPosition;
        pz.z = -0.2f;
        pz.x = pz.x *Camera.main.pixelWidth/Camera.main.aspect;
        pz.y = pz.y *Camera.main.pixelHeight/Camera.main.aspect;
        gameObject.transform.localPosition = pz;
    }*/
}
