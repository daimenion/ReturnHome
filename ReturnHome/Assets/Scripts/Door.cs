using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ghost"))
        {
            //anim.SetTrigger("Enter");
            anim.Play("open");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        /*if (!other.CompareTag("Ghost"))
        {
            anim.SetTrigger("Enter");
        }*/

    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ghost"))
        {
            anim.Play("Close");
            //anim.ResetTrigger("Enter");
        }

    }
    public void Play()
    {
        audio.Play();
    }
}
