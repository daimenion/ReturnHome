using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Puddle : MonoBehaviour
{
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.gameObject && player.isMoving)
        {
            if (Random.Range(0, 100) < 15*Time.deltaTime)
            {
                player.AddEffect("Damp");
                player.GetComponentInChildren<Animator>().Play("Base Layer.Trip", 0, .25f);
            }
        }
    }
}
