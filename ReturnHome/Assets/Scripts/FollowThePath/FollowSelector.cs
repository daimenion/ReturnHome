using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSelector : MonoBehaviour
{
    Vector3 initialPosition;
    public FollowThePath followScript;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.localPosition;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)&&!isActive)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            followScript.isActive = true;
            isActive = true;
        }
    }
    void Update()
    {
        if (isActive && followScript.isActive)
        {
            Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
            Vector3 hitPoint = ray.GetPoint(0);
            transform.position = hitPoint;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.244f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goal")
        {
            followScript.StartCoroutine(followScript.WinGame());
        }
    }
}
