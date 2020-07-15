using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWire : MonoBehaviour
{
    public bool Example;
    public GameObject myGoal;
    public bool isActive = true;
    public int isBroken = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnMouseDrag()
    {
        if (isActive && !Example)
        {
            Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
            Vector3 hitPoint = ray.GetPoint(0);
            transform.position = hitPoint;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.244f);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CTWGoal" && !Input.GetMouseButton(0)&& isActive)
        {
            isActive = false;
            if (other.gameObject == myGoal)
            {
                other.gameObject.tag = "Untagged";
                transform.position = other.transform.position;
                isBroken = 1;
            }
            else
            {
                isBroken = -1;
            }
        }
    }
}
