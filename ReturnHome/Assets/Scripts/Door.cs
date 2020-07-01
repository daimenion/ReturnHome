using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ghost"))
        {
            anim.SetTrigger("Enter");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ghost"))
        {
            anim.SetTrigger("Enter");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ghost"))
        {
            anim.ResetTrigger("Enter");
        }

    }
}
