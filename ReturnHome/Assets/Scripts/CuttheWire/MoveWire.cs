using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWire : MonoBehaviour
{
    public bool Example;
    public GameObject myGoal;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDrag()
    {
        if (isActive && !Example)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 hitPoint = ray.GetPoint(0);
            transform.position = hitPoint;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.244f);
        }
    }
    void OnMouseExit()
    {

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
            }
            else
            {
                print("Fuck You");
            }
        }
    }
}
