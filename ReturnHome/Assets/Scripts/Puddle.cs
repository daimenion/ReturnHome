using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Puddle : MonoBehaviour
{
    PlayerController player;
    AudioSource audio;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.gameObject && player.isMoving)
        {
            if (Random.Range(0, 100) < 15*Time.deltaTime)
            {
                audio.Play();
                player.AddEffect("Damp");
                player.GetComponentInChildren<Animator>().Play("Base Layer.Trip", 0, .25f);
            }
        }
    }
}
