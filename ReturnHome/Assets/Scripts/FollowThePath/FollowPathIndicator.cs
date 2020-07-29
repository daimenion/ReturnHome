using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject goal;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        direction = (goal.transform.localPosition - transform.parent.localPosition).normalized; 
        transform.localRotation = Quaternion.LookRotation(direction,Vector3.up);
        transform.RotateAround(transform.position, transform.up, -90f);
        transform.RotateAround(transform.position, transform.forward, -90f);//Why does it not rotate regularly? We don't know.
    }
}
